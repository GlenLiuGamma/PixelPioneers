using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    //should fix in future
    private string PLAYER_NAME = "player";
    // Update is called once per frame
    void LateUpdate()
    {

        player = GameObject.Find(PLAYER_NAME).transform; 
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
