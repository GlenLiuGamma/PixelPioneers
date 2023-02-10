using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : BasicPlayer
{ 
    protected override void Movement(){
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
    protected override void InitializeParameters()
    {
        rb.gravityScale = 8;
        sr.color = Color.blue;
        moveSpeed = 25f;
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    protected override void AddDeadLayers()
    {

    }
}
