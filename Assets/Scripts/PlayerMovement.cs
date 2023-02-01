using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float dirX = 0f;

    private float ability_countdown = 5f;

    private float cooldown_countdown = 5f;

    private bool switchable = true;
    private bool is_cooldown = false;
    private bool move = true;

    private bool mode = false;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float RunningSpeed = 20f;
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] Color  Running_Color;

    [SerializeField] Color Water_Color;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        move = true;
       
        Debug.Log("The game is set");        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false) {
            Debug.Log("not yet");
        } else if (move) {
            movement();
        }
         
        if (Input.GetKeyDown("c")) {
            if (switchable) {
                if (mode) {
                    Debug.Log("mode = " + mode);
                    moveSpeed = 7f;
                    sr.color = Color.red;
                    mode = false;
                }
                else if (mode == false) {
                    Debug.Log("mode = " + mode);
                    moveSpeed = RunningSpeed;
                    sr.color = Color.blue;
                    mode = true;
                    
                }
            } else {
                Debug.Log("Still cooling down, hang on ");
            }

        } else {
            if (mode == true){
                ability_countdown -= 1 * Time.deltaTime;
                if (ability_countdown < 0) {
                    switchable = false;
                    move = false;
                    mode = false;
                    sr.color = Color.red;
                }
            } else {
                is_cooldown = true;
                cooldown_countdown -= 1 * Time.deltaTime;
                if (cooldown_countdown < 0) {
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

    void movement() {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space")) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


}
