using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.FinishLevel += onPlayerFinish;
    }

    private void onPlayerFinish()
    {
        Debug.Log("Trigger finish event");
    }


       private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameEvent.current.FinishTrigger();
        } 
    }
}
