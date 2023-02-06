using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangle_contact : MonoBehaviour
{

    private void Start() {
        GameEvent.current.Death += onPlayerDeath;
    }

    private void onPlayerDeath()
    {
        Debug.Log("Trigger die event");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.blue){
                Destroy(this.gameObject);
                Debug.Log("The box is crashed");
            }else {
                Debug.Log("you touch the enemy");
                GameEvent.current.DeathTriggerCount();
                other.gameObject.transform.position = new Vector2(-10,1);
            }
            
        } 
    }
}
