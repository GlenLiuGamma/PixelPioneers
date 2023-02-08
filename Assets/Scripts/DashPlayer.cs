using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : BasicPlayer
{
    [SerializeField] protected float moveSpeed = 25f;

    protected override void Movement(){
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
}
