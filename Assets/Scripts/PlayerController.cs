using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    private string[] playerList = { "BasicPlayer", "DashPlayer","AntiGravityPlayer" };
    private bool isBasicPlayer = true;
    private float timeLeft = 10f;
    private Text timeLeftDisplay;
    private GameObject dashPlayerUI;
    private GameObject antigravityPlayerUI;
    // Start is called before the first frame update
    void Start()
    {
        player.AddComponent<BasicPlayer>();
        isBasicPlayer = true;
        timeLeftDisplay = GameObject.Find("TimeLeft").GetComponent<Text>();
        dashPlayerUI = GameObject.Find("Canvas/DashPlayerUI");
        antigravityPlayerUI = GameObject.Find("Canvas/AntiGravityPlayer");
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
        timeLeftDisplay.text = ((int)timeLeft).ToString();
        if (!isBasicPlayer){
            timeLeft-= 1 * Time.deltaTime;
        }
        if(timeLeft < 0){
            timeLeft = 0;
            isBasicPlayer = true;
            DestroyAll();
            player.AddComponent<BasicPlayer>();
            SetUIColorToGray();
        }
    }
    private void SetUIColorToGray()
    {

        dashPlayerUI.GetComponent<SpriteRenderer>().color = Color.gray;
        antigravityPlayerUI.GetComponent<SpriteRenderer>().color = Color.gray;
    }
    private void ResetUIColor()
    {
        dashPlayerUI.GetComponent<SpriteRenderer>().color = Color.blue;
        antigravityPlayerUI.GetComponent<SpriteRenderer>().color = Color.yellow;
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
        ResetUIColor();
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
