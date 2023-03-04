using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    protected string PLAYER_NAME = "player";
    private GameObject player; 
    [SerializeField] private KeyCode[] keys = {KeyCode.Z, KeyCode.X, KeyCode.C};
    [SerializeField] private HashSet<KeyCode> enableKeys = new HashSet<KeyCode>();
    private string[] playerList = { "BasicPlayer", "DashPlayer","AntiGravityPlayer" };
    private bool isBasicPlayer = true;
    public float timeLeft = 10f;
    private Text timeLeftDisplay;
    private GameObject dashPlayerUI;
    private GameObject antigravityPlayerUI;
    // Start is called before the first frame update
    void Awake(){
        foreach(KeyCode key in keys){
            enableKeys.Add(key);
        }
    }
    void Start()
    {
        player = GameObject.Find(PLAYER_NAME);
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
        if ( enableKeys.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.Z))
        {
            isBasicPlayer = true;
            Debug.Log("Pressed Z");
            DestroyAll();
            player.AddComponent<BasicPlayer>();
        }
        if (timeLeft > 0 && enableKeys.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.X))
        {
            isBasicPlayer = false;
            Debug.Log("Pressed X");
            DestroyAll();
            player.AddComponent<DashPlayer>();
        }
        if (timeLeft > 0 && enableKeys.Contains(KeyCode.C) && Input.GetKeyDown(KeyCode.C))
        {
            isBasicPlayer = false;
            Debug.Log("Pressed C");
            DestroyAll();
            player.AddComponent<AntiGravityPlayer>();
        }
    }
    private void UpdateTime(){
        timeLeftDisplay.text = Mathf.CeilToInt(timeLeft).ToString();
        if (!isBasicPlayer){
            timeLeft-= 1 * Time.deltaTime;
            timeLeftDisplay.color = Color.red;
        }else{
            timeLeftDisplay.color = Color.black;
        }
        if(timeLeft < 0){
            timeLeft = 0;
            timeLeftDisplay.color = Color.red;
            isBasicPlayer = true;
            DestroyAll();
            player.AddComponent<BasicPlayer>();
            SetUIColorToGray();
        }
        else if (timeLeft > 0){
            ResetUIColor();
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
    IEnumerator WaitToStartGame()
    {
        ResetUIColor();
        timeLeft = 10f;
        isBasicPlayer = true;
        DestroyAll();
        yield return new WaitForSecondsRealtime(0.01f);
        player.AddComponent<BasicPlayer>();
        
    }
    void RestartGame()
    { 
        StartCoroutine(WaitToStartGame());
    }
    void GetExtraTime(float timeBonus)
    {
        timeLeft += timeBonus;
    }
    private void OnEnable()
    {
        BasicPlayer.onGameOver += RestartGame;
        TimeReward.timeRewardDelegate += GetExtraTime;
    }
    private void OnDisable()
    {
        BasicPlayer.onGameOver -= RestartGame;
        TimeReward.timeRewardDelegate -= GetExtraTime;
    }
}

