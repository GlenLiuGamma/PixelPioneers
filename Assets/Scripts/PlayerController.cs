using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    private string[] playerList = { "BasicPlayer", "DashPlayer","AntiGravityPlayer" };
    private bool isBasicPlayer = true;
    private float timeLeft = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player.AddComponent<BasicPlayer>();
        isBasicPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        SwitchPlayer();
        UpdateTime();

    }

    private void SwitchPlayer()
    {
        if ( Input.GetKeyDown(KeyCode.Z))
        {
            isBasicPlayer = true;
            Debug.Log("Pressed Z");
            DestroyAll();
            player.AddComponent<BasicPlayer>();
        }
        if (timeLeft > 0 && Input.GetKeyDown(KeyCode.X))
        {
            isBasicPlayer = false;
            Debug.Log("Pressed X");
            DestroyAll();
            player.AddComponent<DashPlayer>();
        }
        if (timeLeft > 0 && Input.GetKeyDown(KeyCode.C))
        {
            isBasicPlayer = false;
            Debug.Log("Pressed C");
            DestroyAll();
            player.AddComponent<AntiGravityPlayer>();
        }
    }
    private void UpdateTime(){
        Debug.Log(timeLeft);
        if (!isBasicPlayer){
            timeLeft-= 1 * Time.deltaTime;
        }
        if(timeLeft < 0){
            timeLeft = 0;
            isBasicPlayer = true;
            DestroyAll();
            player.AddComponent<BasicPlayer>();
        }
    }

    private void DestroyAll()
    {
        foreach(string playerType in playerList)
        {
            Destroy(player.GetComponent(playerType));
        }
    }

    void RestartGame()
    { 
        timeLeft = 10f;
        isBasicPlayer = true;
        DestroyAll();
        player.AddComponent<BasicPlayer>();
    }
    private void OnEnable()
    {
        BasicPlayer.onGameOver += RestartGame;
    }
    private void OnDisable()
    {
        BasicPlayer.onGameOver -= RestartGame;
    }
}
