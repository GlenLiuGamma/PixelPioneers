using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShowHiddenPath : MonoBehaviour
{
    public GameObject HiddenPath;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            HiddenPath.SetActive(false);
        }
    }
}
