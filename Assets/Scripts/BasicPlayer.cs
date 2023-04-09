using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BasicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    protected string GROUND_LAYER = "Ground";
    protected string WATER_LAYER = "Water";
    protected string WATER_TAG = "Water";
    protected string TRAP_TAG = "Trap";
    protected string BOUND_TAG = "Bound";
    protected string RESPAWN = "respawn";

    string DEATH_ANIMATION_TRIGGER = "death";
    protected string ENEMY_TAG = "enemy";

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
    [SerializeField] protected LayerMask water;
    [SerializeField] protected List<LayerMask> DeadLayers = new List<LayerMask>();

    protected Text timepopup;

    protected Image jumpingtext;

    protected float timer = 0f;

    protected float timer_jump = 0f;

    protected float offset = 0.5f;

    protected float offset_jump = 2.0f;

    protected bool isShow;

    protected bool show_reward;

    protected bool show_jump;



    public delegate void OnGameOver();
    public static OnGameOver onGameOver;

    public GameObject startpoint;
    public GameObject game_manager;

    protected GameObject pauseMenuUI;

    private Color playerTextColor = new Color(33, 105, 52);
    private Animator anim;

    protected GameObject shield;
    public static float shieldTimeLeft = 3f;



    private enum MovementState { idle, running, jump, fall };
    private MovementState state = MovementState.idle;
    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        // DeactivateShield();

        //pauseMenuUI = GameObject.Find("PauseMenu");
        //pauseMenuUI.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        BasicPlayerText = GameObject.Find("BasicPlayerText").GetComponent<Text>();
        DashPlayerText = GameObject.Find("DashPlayerText").GetComponent<Text>();
        AntigravityPlayerText = GameObject.Find("AntigravityPlayerText").GetComponent<Text>();

        ground = LayerMask.GetMask(GROUND_LAYER);
        water = LayerMask.GetMask(WATER_LAYER);
        startpoint = GameObject.Find(RESPAWN);
        game_manager = GameObject.Find("GameManager");

        timepopup = GameObject.Find("timepop").GetComponent<Text>();
        timepopup.enabled = false;
        isShow = false;

        jumpingtext = GameObject.Find("jumping").GetComponent<Image>();
        jumpingtext.enabled = false;

        show_reward = false;
        show_jump = false;


        AddDeadLayers();
        InitializeParameters();
    }

    protected virtual void AddDeadLayers()
    {
        DeadLayers.Add(LayerMask.GetMask(WATER_LAYER));
    }
    // Update is called once per frame

    protected virtual void InitializeParameters()
    {
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));
        rb.gravityScale = 8;
        sr.color = Color.white;
        BasicPlayerText.color = Color.white;
        DashPlayerText.color = Color.black;
        AntigravityPlayerText.color = Color.black;
    }

    void Update()
    {
        if (Shield.shieldDestroied)
        {
            Debug.Log("hhhhhhhhhhhhhhh");
            shieldTimeUpdate();
        }
        if (isShow)
        {
            if (timer > offset)
            {
                timepopup.enabled = false;
                show_reward = false;
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }

            if (timer_jump > offset_jump)
            {
                jumpingtext.enabled = false;
                show_jump = false;
                timer_jump = 0f;
            }
            else
            {
                timer_jump += Time.deltaTime;
            }
        }

        Movement();
        UpdatePlayerAnimation();
        CheckStandingOn(DeadLayers);
    }

    protected virtual void Movement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // player can jumps or changes his gravity only when he touches the ground 
        if (Input.GetKeyDown("space") && (IsStandingOn(ground) || IsStandingOn(water)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }



    }
    private void UpdatePlayerAnimation()
    {
        //MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        if (dirX == 0f)
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        anim.SetInteger("state", (int)state);
    }

    private void CheckStandingOn(List<LayerMask> DeadLayers)
    {
        foreach (LayerMask layer in DeadLayers)
        {
            if (IsStandingOn(layer))
            {
                if (HasShield())
                {
                    Shield.shieldDestroied = true;
                }
                else
                {
                    Die(WATER_TAG);
                    break;
                }
            }
        }
    }
    // if the player is touching the ground
    private bool IsStandingOn(LayerMask layer)
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, layer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("time_reward"))
        {
            timepopup.enabled = true;
            show_reward = true;
            isShow = true;

        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(TRAP_TAG))
        {
            if (HasShield())
            {
                Shield.shieldDestroied = true;
            }
            else
            {
                string DeathReason = "";
                DeathReason = TRAP_TAG;
                Debug.Log(DeathReason);
                Die(DeathReason);
            }
        }
        else if (other.gameObject.CompareTag(WATER_TAG))
        {
            if (HasShield())
            {
                Shield.shieldDestroied = true;
            }
            else
            {
                string DeathReason = "";
                DeathReason = WATER_TAG;
                Debug.Log(DeathReason);
                Die(DeathReason);
            }
        }
        else if (other.gameObject.CompareTag(BOUND_TAG))
        {
            if (HasShield())
            {
                Shield.shieldDestroied = true;
            }
            else
            {
                string DeathReason = "";
                DeathReason = BOUND_TAG;
                Debug.Log(DeathReason);
                Die(DeathReason);
            }
        }
        else if (other.gameObject.CompareTag("time_reward"))
        {
            timepopup.enabled = true;
            show_reward = true;
            isShow = true;
        }
        else if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            if (HasShield())
            {
                Destroy(other.gameObject);
                Shield.shieldDestroied = true;
            }
            else
            {
                string DeathReason = "";
                DeathReason = ENEMY_TAG;
                Debug.Log(DeathReason);
                Die(DeathReason);
            }
        }


    }

    protected bool HasShield()
    {
        return shield.activeSelf;
    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }
    private void shieldTimeUpdate()
    {
        if (HasShield())
        {
            shieldTimeLeft -= 1 * Time.deltaTime;
            Debug.Log(shieldTimeLeft);
            if (shieldTimeLeft < 0)
            {
                DeactivateShield();
                Shield.shieldDestroied = false;
            }
        }
    }

    private void DeadAnimation()
    {
        anim.SetTrigger(DEATH_ANIMATION_TRIGGER);
        rb.bodyType = RigidbodyType2D.Static;
    }

    protected void Die(string DeathReason)
    {
        // if(HasShield()){
        //     // shieldTimeLeft = 5;
        //     shieldDestroied = true;
        // }else{
        //string DeathReason = "";water, detected by the tower, out of bound
        string DeathPosition = "(";
        DeathPosition += transform.position.x.ToString();
        DeathPosition += ", ";
        DeathPosition += transform.position.y.ToString();
        DeathPosition += ")";
        Debug.Log("Death position: " + DeathPosition);

        string DeathCharacter = "";
        if (sr.color == Color.white)
        {
            DeathCharacter = "BasicPlayer";
        }
        else if (sr.color == Color.blue)
        {
            DeathCharacter = "DashPlayer";
        }
        else if (sr.color == Color.yellow)
        {
            DeathCharacter = "AntiGravityPlayer";
        }

        SendToGoogle stg = game_manager.GetComponent<SendToGoogle>();
        GameEvent game_event = game_manager.GetComponent<GameEvent>();
        DataStorage.Deathcnt += 1;
        stg.Send(DeathPosition, DeathReason, DeathCharacter);
        //Enable pause menu scene
        /* pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
        pauseMenuUI.transform.Find("GameOver").transform.gameObject.SetActive(true);
        pauseMenuUI.SetActive(true);*/
        DeadAnimation();
        onGameOver?.Invoke();
        // }
    }

}
