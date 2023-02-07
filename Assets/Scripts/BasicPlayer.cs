using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D coll;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private List<LayerMask>  DeadLayers;
    
    public GameObject startpoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        ground = LayerMask.GetMask("terrain");
        DeadLayers.Add(LayerMask.GetMask("Water"));
    }
    // Update is called once per frame

    void Update()
    {
        Movement();
        CheckStandingOn(DeadLayers);
    }

    void Movement(){
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Water")){
            Die();
        }
    }
    private void Die(){
        transform.position = startpoint.transform.position;
    }

}
