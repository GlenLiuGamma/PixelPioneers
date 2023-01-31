using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float dirX = 0f;

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
       
        Debug.Log("The game is set");        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space")) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
         
        if (Input.GetKeyDown("c")) {
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
        }

        
    }


}
