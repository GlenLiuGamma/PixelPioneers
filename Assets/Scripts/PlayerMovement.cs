using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D coll;
    private float dirX = 0f;

    private float ability_countdown = 5f;

    private float cooldown_countdown = 5f;

    private bool switchable = true;
    private bool is_cooldown = false;
    private bool move = true;
    private bool top;
    // check if player is in the middle of jumping
    private bool midjump = false;

    //mode -> form, because we have several modes
    private bool mode = false;
    // normal: 0, running fast: 1, change gravity: 2
    private int form = 0; 
    // the player can change his forms twice
    public static int change_Form_Times = 2;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float RunningSpeed = 20f;
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] Color  Running_Color;

    [SerializeField] Color Water_Color;

    [SerializeField] bool groundTester;

    // display the times left for player to change his form
    [SerializeField] private Text power;
    // display system information
    [SerializeField] private Text info;

    // all the gorund is setted to be groundLayer
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        move = true;
       
        Debug.Log("The game is set");        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false) {
            Debug.Log("not yet");
            info.text = "not yet";
        } else if (move) {
            movement();
        }
         
        completeForm1();
        completeForm0();
        completeForm2();
        playerDead();
    }
    
    // player will turn to default form when player is dead
    void playerDead(){
        if(DetectCollision.isDead){
            change_Form_Times = 2;
            power.text = "Power Left: " + change_Form_Times;
            form = 0;
            DetectCollision.isDead = false;
            info.text = "Restart";
        }
    }
    // change gravity form
    void completeForm2(){
        
        if(Input.GetKeyDown("2") && change_Form_Times > 0 && form != 2 && switchable == true){
            form = 2;
            change_Form_Times -= 1;
            power.text = "Power Left: " + change_Form_Times;
            ability_countdown = 5;
            sr.color = Color.yellow;
        }else{
            if(form == 2){
                // form 2 can last for 5 seconds
                ability_countdown -= 1 * Time.deltaTime;
                if (ability_countdown < 0) {
                    sr.color = Color.red;
                    // change gravity to form0's
                    if(rb.gravityScale < 0){
                        rb.gravityScale *= -1;
                    }
                    form = 0;
                }
            }
        }
    }

    void completeForm1() {
        if (Input.GetKeyDown("1") && change_Form_Times > 0) {
            if (switchable) {
                if (form == 0) {  
                    change_Form_Times -= 1;
                    power.text = "Power Left: " + change_Form_Times;
                    moveSpeed = RunningSpeed;
                    sr.color = Color.blue;
                    form = 1;;
                    
                }
            } else {
                info.text = "Still cooling down, hang on ";
                Debug.Log("Still cooling down, hang on ");
            }

        } else {
            if (form == 1){
                ability_countdown -= 1 * Time.deltaTime;
                if (ability_countdown < 0) {
                    switchable = false;
                    move = false;
                    form = 0;
                    sr.color = Color.red;
                }
            } else {
                is_cooldown = true;
                cooldown_countdown -= 1 * Time.deltaTime;
                if (cooldown_countdown < 0) {
                    info.text = ("You are good to go!");
                    Debug.Log("You are good to go!");
                    switchable = true;
                    move = true;
                    ability_countdown = 5f;
                    cooldown_countdown = 5f;
                    is_cooldown = false;
                }
            }
        }
    }

    // default form
    void completeForm0(){
        if(Input.GetKeyDown("0") && form != 0){
            form = 0;
            if(rb.gravityScale < 0){
                rb.gravityScale *= -1;
            }
            sr.color = Color.red;
        }else{
            if(form == 0){
                if(rb.gravityScale < 0){
                    rb.gravityScale *= -1;
                }
                sr.color = Color.red;
            }
        }
    }

    // make the player up side down when change the gravity
    void FlipUp(){
        if(top == false){
            transform.eulerAngles = new Vector3(0,0,180f);
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }

    // if the player is touching the ground
    private bool IsGround(){
        groundTester = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, groundLayer);
        return groundTester;
        
    }
    void movement() {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        dirX = Input.GetAxisRaw("Horizontal");
        // player can jumps or changes his gravity only when he touches the ground 
        if (Input.GetKeyDown("space") && form == 0 && IsGround() && midjump == false) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            midjump = true;
        }else if(Input.GetKeyDown("space") && form == 2){
            rb.gravityScale *= -1;
            Debug.Log(Physics2D.gravity);
            FlipUp();
            midjump = true;
        }
        if (rb.velocity.y == 0){
            midjump = false;
        }
    }


}