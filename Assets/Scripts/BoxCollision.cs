using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.blue){
                Destroy(this.gameObject);
                Debug.Log("The box is crashed");
            }
            
        } 
    }
}
