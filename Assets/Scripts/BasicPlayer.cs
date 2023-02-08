using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    protected string GROUND_LAYER = "Ground";
    protected string WATER_LAYER = "Water";
    protected string WATER_TAG = "Water";
    protected string TRAP_TAG = "Trap";
    protected string RESPAWN = "respawn";

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected BoxCollider2D coll;
    protected float dirX = 0f;
    [SerializeField] protected float moveSpeed = 16f;
    [SerializeField] protected float jumpForce = 30f;
    [SerializeField] protected LayerMask ground;
    [SerializeField] protected List<LayerMask>  DeadLayers = new List<LayerMask>();
    
    public delegate void OnGameOver();
    public static OnGameOver onGameOver;

    public GameObject startpoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        ground = LayerMask.GetMask(GROUND_LAYER);
        startpoint = GameObject.Find(RESPAWN);
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
                Die();
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
        if (other.gameObject.CompareTag(TRAP_TAG) || other.gameObject.CompareTag(WATER_TAG)){
            Die();
        }
    }
    protected void Die(){
        transform.position = startpoint.transform.position;
        onGameOver?.Invoke();
    }

}
