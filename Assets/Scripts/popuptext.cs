using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popuptext : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject timepopup;


    void Start()
    {
        timepopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("time_reward")) {
            Debug.Log("testing collition on time_reward");
        }
    }
}
