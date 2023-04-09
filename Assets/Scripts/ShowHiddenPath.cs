using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShowHiddenPath : MonoBehaviour
{
    public CameraController isZooming;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            //camera.transform.position = Vector3.MoveTowards(camera.transform.position, destination.transform.position, 3 * Time.deltaTime);
            
            isZooming._isZooming = true;
            Destroy(this.gameObject);
            
        }
    }
}
