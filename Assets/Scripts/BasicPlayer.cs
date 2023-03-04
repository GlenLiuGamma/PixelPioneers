using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    protected string GROUND_LAYER = "Ground";
    protected string WATER_LAYER = "Water";
    protected string WATER_TAG = "Water";
    protected string TRAP_TAG = "Trap";
    protected string BOUND_TAG = "Bound";
    protected string RESPAWN = "respawn";

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected BoxCollider2D coll;
    protected float dirX = 0f;

    protected Text BasicPlayerText;
    protected Text DashPlayerText;
    protected Text AntigravityPlayerText;
    [SerializeField] protected float moveSpeed = 16f;
    [SerializeField] protected float jumpForce = 30f;
    [SerializeField] protected LayerMask ground;
    [SerializeField] protected List<LayerMask>  DeadLayers = new List<LayerMask>();
    
    
    
    public delegate void OnGameOver();
    public static OnGameOver onGameOver;

    public GameObject startpoint;
    public GameObject game_manager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        BasicPlayerText = GameObject.Find("BasicPlayerText").GetComponent<Text>();
        DashPlayerText = GameObject.Find("DashPlayerText").GetComponent<Text>();
        AntigravityPlayerText = GameObject.Find("AntigravityPlayerText").GetComponent<Text>();

        ground = LayerMask.GetMask(GROUND_LAYER);
        startpoint = GameObject.Find(RESPAWN);
        game_manager = GameObject.Find("GameManager");

        AddDeadLayers();
        InitializeParameters();
    }

    protected virtual void AddDeadLayers(){
        DeadLayers.Add(LayerMask.GetMask(WATER_LAYER));
    }
    // Update is called once per frame

    protected virtual void InitializeParameters(){
        rb.gravityScale = 8;
        sr.color = Color.white;
        BasicPlayerText.color = Color.green;
        DashPlayerText.color = Color.black;
        AntigravityPlayerText.color = Color.black;
    }

    void Update()
    {
        Movement();
        CheckStandingOn(DeadLayers);
    }

    protected virtual void Movement(){
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // player can jumps or changes his gravity only when he touches the ground 
        if (Input.GetKeyDown("space") && IsStandingOn(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void CheckStandingOn(List<LayerMask> DeadLayers){
        foreach (LayerMask layer in DeadLayers){
            if (IsStandingOn(layer)){
                Die(WATER_TAG);
                break;
            }
        }
    }
    // if the player is touching the ground
    private bool IsStandingOn(LayerMask layer)
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, layer);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag(TRAP_TAG)){
            string DeathReason = "";   
            DeathReason = TRAP_TAG;
            Debug.Log(DeathReason);
            Die(DeathReason);
        }
        else if (other.gameObject.CompareTag(WATER_TAG)){
             string DeathReason = "";   
            DeathReason = WATER_TAG;
            Debug.Log(DeathReason);
            Die(DeathReason);
        }
        else if (other.gameObject.CompareTag(BOUND_TAG)) {
            string DeathReason = "";   
            DeathReason = BOUND_TAG;
            Debug.Log(DeathReason);
            Die(DeathReason);
        }
    }

    protected void Die(string DeathReason){
        
        //string DeathReason = "";water, detected by the tower, out of bound
        string DeathPosition = "(";
        DeathPosition += transform.position.x.ToString();
        DeathPosition += ", ";
        DeathPosition += transform.position.y.ToString();
        DeathPosition += ")";
        Debug.Log("Death position: " + DeathPosition);

        string DeathCharacter = "";
        if (sr.color == Color.white){
            DeathCharacter = "BasicPlayer";
        }
        else if (sr.color == Color.blue){
            DeathCharacter = "DashPlayer";
        }
        else if (sr.color == Color.yellow){
            DeathCharacter = "AntiGravityPlayer";
        }
        
        SendToGoogle stg = game_manager.GetComponent<SendToGoogle>();
        GameEvent game_event = game_manager.GetComponent<GameEvent>();
        DataStorage.Deathcnt += 1;
        stg.Send(DeathPosition, DeathReason, DeathCharacter);
        transform.position = startpoint.transform.position;
        onGameOver?.Invoke();
    }

}
