using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityPlayer : BasicPlayer
{
    protected override void Movement(){
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // player can jumps or changes his gravity only when he touches the ground 
        if (Input.GetKeyDown("space"))
        {
            rb.gravityScale *= -1;
        }
    }
}
