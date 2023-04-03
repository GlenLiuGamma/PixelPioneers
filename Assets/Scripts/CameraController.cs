using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    //should fix in future
    private string PLAYER_NAME = "player";
    [SerializeField] private float shift_x = 10f;
    [SerializeField] private float shift_y = 6f;

    // Update is called once per frame
    void LateUpdate()
    {

        playerTransform = GameObject.Find(PLAYER_NAME).transform; 
        transform.position = new Vector3(playerTransform.position.x + shift_x, playerTransform.position.y + shift_y, transform.position.z);
    }
}
