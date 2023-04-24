using UnityEngine;

public class AntiGravityPlayer : BasicPlayer
{
    protected override void Movement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // player can jumps or changes his gravity only when he touches the ground 
        if (Input.GetKeyDown("space"))
        {
            rb.gravityScale *= -1;
            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }
    }
    protected override void InitializeParameters()
    {
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));
        rb.gravityScale = 8;
        sr.color = PlayerController.antigravityPlayerUsingColor;
        BasicPlayerText.color = Color.black;
        DashPlayerText.color = Color.black;
        AntigravityPlayerText.color = PlayerController.antigravityPlayerUsingColor;
        basicPlayerUI.color = PlayerController.basicPlayerIdleColor;
        antigravityPlayerUI.color = PlayerController.antigravityPlayerUsingColor;
        dashPlayerUI.color = PlayerController.dashPlayerIdleColor;
    }
}
