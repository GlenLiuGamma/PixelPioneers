using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    private string[] playerList = { "BasicPlayer", "DashPlayer","AntiGravityPlayer" };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
    }

    private void SwitchPlayer()
    {
        if ( Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Pressed Z");
            DestroyAll();
            player.AddComponent<BasicPlayer>();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Pressed X");
            DestroyAll();
            player.AddComponent<DashPlayer>();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Pressed X");
            DestroyAll();
            player.AddComponent<AntiGravityPlayer>();
        }
    }
    private void DestroyAll()
    {
        foreach(string playerType in playerList)
        {
            Destroy(player.GetComponent(playerType));
        }
    }
}
