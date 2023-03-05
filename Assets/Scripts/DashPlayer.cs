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
        BasicPlayerText.color = Color.black;
        DashPlayerText.color = Color.green;
        AntigravityPlayerText.color = Color.black;
        moveSpeed = 25f;
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bound"))
        {
            string DeathReason = BOUND_TAG;
            Die(DeathReason);
        } else if (other.gameObject.CompareTag("Trap")){
            string DeathReason = TRAP_TAG;
            Die(DeathReason);
        }else if (other.gameObject.CompareTag("time_reward")) {
            timepopup.enabled = true;
            isShow = true;
        }
    }
    protected override void AddDeadLayers()
    {

    }
}
