using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    protected string PLAYER_NAME = "player";
    private GameObject player;
    [SerializeField] private KeyCode[] keys = { KeyCode.Z, KeyCode.X, KeyCode.C };
    [SerializeField] private HashSet<KeyCode> enableKeys = new HashSet<KeyCode>();
    private string[] playerList = { "BasicPlayer", "DashPlayer", "AntiGravityPlayer" };
    public static bool isBasicPlayer = true;
    public static bool isAntiGravityPlayer = false;
    public static bool isDashPlayer = false;
    public float timeLeft = 10f;
    private Text timeLeftDisplay;
    private GameObject basicPlayerUI;
    private GameObject dashPlayerUI;
    private GameObject antigravityPlayerUI;

    public static Color basicPlayerIdleColor = new Color(255f / 255, 255f / 255, 255f / 255, 96f / 255);
    public static Color basicPlayerUsingColor = new Color(255f / 255, 255f / 255, 255f / 255, 255f / 255);

    public static Color dashPlayerIdleColor = new Color(0f / 255, 149f / 255, 255f / 255, 96f / 255);
    public static Color dashPlayerUsingColor = new Color(0f / 255, 149f / 255, 255f / 255, 255f / 255);

    public static Color antigravityPlayerIdleColor = new Color(255f / 255, 255f / 255, 0f / 255, 96f / 255);
    public static Color antigravityPlayerUsingColor = new Color(255f / 255, 255f / 255, 0f / 255, 255f / 255);

    public static Color deathColor = new Color(0f / 255, 0f / 255, 0f / 255, 96f / 255);


    public static Vector3? lastCheckPointPos = null;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (KeyCode key in keys)
        {
            enableKeys.Add(key);
        }
        if (lastCheckPointPos != null)
        {
            player = GameObject.Find(PLAYER_NAME);
            player.transform.position = lastCheckPointPos.Value;
        }
    }
    void Start()
    {
        player = GameObject.Find(PLAYER_NAME);
        player.AddComponent<BasicPlayer>();
        isBasicPlayer = true;
        isAntiGravityPlayer = false;
        isDashPlayer = false;
        timeLeftDisplay = GameObject.Find("TimeLeft").GetComponent<Text>();
        basicPlayerUI = GameObject.Find("Canvas/BasicPlayerUI");
        dashPlayerUI = GameObject.Find("Canvas/DashPlayerUI");
        antigravityPlayerUI = GameObject.Find("Canvas/AntiGravityPlayerUI");
    }

    // Update is called once per frame
    void Update()
    {

        SwitchPlayer();
        UpdateTime();

    }

    private void SwitchPlayer()
    {
        if (enableKeys.Contains(KeyCode.Z) && Input.GetKeyDown(KeyCode.Z) && !isBasicPlayer)
        {
            isBasicPlayer = true;
            isAntiGravityPlayer = false;
            isDashPlayer = false;
            Debug.Log("Pressed Z");
            DestroyAll();
            player.AddComponent<BasicPlayer>();
        }
        if (timeLeft > 0 && enableKeys.Contains(KeyCode.X) && Input.GetKeyDown(KeyCode.X) && !isDashPlayer)
        {
            isBasicPlayer = false;
            isAntiGravityPlayer = false;
            isDashPlayer = true;
            Debug.Log("Pressed X");
            DestroyAll();
            player.AddComponent<DashPlayer>();
        }
        if (timeLeft > 0 && enableKeys.Contains(KeyCode.C) && Input.GetKeyDown(KeyCode.C) && !isAntiGravityPlayer)
        {
            isBasicPlayer = false;
            isAntiGravityPlayer = true;
            isDashPlayer = false;
            Debug.Log("Pressed C");
            DestroyAll();
            player.AddComponent<AntiGravityPlayer>();
        }
    }
    private void UpdateTime()
    {
        timeLeftDisplay.text = Mathf.CeilToInt(timeLeft).ToString();
        if (!isBasicPlayer)
        {
            timeLeft -= 1 * Time.deltaTime;

            timeLeftDisplay.color = Color.red;
            if (timeLeft < 10)
            {
                if (((int)(timeLeft * 10)) % 2 == 0)
                {
                    timeLeftDisplay.color = Color.red;
                }
                else
                {
                    timeLeftDisplay.color = Color.clear;
                }
            }
        }
        else
        {
            timeLeftDisplay.color = Color.white;
        }
        if (timeLeft < 0)
        {
            timeLeft = 0;
            timeLeftDisplay.color = Color.red;
            isBasicPlayer = true;
            DestroyAll();
            StartCoroutine(AddComponentAndWait());

        }
        else if (timeLeft > 0 && isBasicPlayer)
        {
            ResetUIColor();
        }
    }
    private IEnumerator AddComponentAndWait()
    {
        // Add a new component
        player.AddComponent<BasicPlayer>();

        // Wait until the component is added
        yield return null;

        // Now execute the code in the original file
        SetUIColorToGray();
    }
    private void SetUIColorToGray()
    {

        dashPlayerUI.GetComponent<SpriteRenderer>().color = deathColor;
        antigravityPlayerUI.GetComponent<SpriteRenderer>().color = deathColor;
    }
    private void ResetUIColor()
    {
        dashPlayerUI.GetComponent<SpriteRenderer>().color = dashPlayerIdleColor;
        antigravityPlayerUI.GetComponent<SpriteRenderer>().color = antigravityPlayerIdleColor;
    }
    private void DestroyAll()
    {
        foreach (string playerType in playerList)
        {
            Destroy(player.GetComponent(playerType));
        }
    }
    IEnumerator WaitToStartGame()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        ResetUIColor();
        timeLeft = 10f;
        isBasicPlayer = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

