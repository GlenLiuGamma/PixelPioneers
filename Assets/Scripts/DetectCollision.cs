using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    public GameObject startpoint;
    public GameObject Player;
    public static bool isDead = false;
    // Start is called before the first frame update

     private void Start() {
        GameEvent.current.Death += onPlayerDeath;
    }

    private void onPlayerDeath()
    {
        Debug.Log("Trigger die event");
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponent<SpriteRenderer>().color != Color.blue)
            Die();
        } 
    }


    private void Die() {
         Debug.Log("The player is dead");
         isDead = true;
         GameEvent.current.DeathTriggerCount();
         Player.transform.position = startpoint.transform.position;
         
    }
}
