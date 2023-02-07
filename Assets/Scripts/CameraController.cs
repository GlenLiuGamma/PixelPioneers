using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    //should fix in future
    private string PLAYER_NAME = "player";
    // Update is called once per frame
    void LateUpdate()
    {

        playerTransform = GameObject.Find(PLAYER_NAME).transform; 
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
