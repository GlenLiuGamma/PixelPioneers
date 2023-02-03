using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    public GameObject startpoint;
    public GameObject Player;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponent<SpriteRenderer>().color != Color.blue)
            Die();
        } 
    }


    private void Die() {
         Debug.Log("The player is dead");
         Player.transform.position = startpoint.transform.position;
    }
}
