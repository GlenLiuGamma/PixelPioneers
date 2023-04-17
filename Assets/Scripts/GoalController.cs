using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SendToGoogle stg;
    public GameObject pauseMenuUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Goal_Level1"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);
            Debug.Log("Pass the tutorial after pauseMenuUI");
            //pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            //pauseMenuUI.SetActive(true);
            string DeathReason = "Goal_Level1";
            string GoalPosition = "Goal_Level1";
            string CurrentCharacter = "Goal_Level1";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
            // SceneManager.LoadScene("GameOver");//Final stage will load the GameOver Scene
        }
        else if (other.gameObject.CompareTag("Goal_Tutorial1"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);
            Debug.Log("Pass the tutorial after pauseMenuUI");

            string DeathReason = "Goal_Tutorial1";
            string GoalPosition = "Goal_Tutorial1";
            string CurrentCharacter = "Goal_Tutorial1";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
            //SceneManager.LoadScene("Tutorial2");
        }
        else if (other.gameObject.CompareTag("Goal_Tutorial2"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);

            string DeathReason = "Goal_Tutorial2";
            string GoalPosition = "Goal_Tutorial2";
            string CurrentCharacter = "Goal_Tutorial2";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
        }
        else if (other.gameObject.CompareTag("Goal_Level2"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);
            Debug.Log("touching goal");
            string DeathReason = "Goal_Level2";
            string GoalPosition = "Goal_Level2";
            string CurrentCharacter = "Goal_Level2";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
        }
        else if (other.gameObject.CompareTag("Goal_Level3"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);
            Debug.Log("touching goal");
            string DeathReason = "Goal_Level3";
            string GoalPosition = "Goal_Level3";
            string CurrentCharacter = "Goal_Level3";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
            // SceneManager.LoadScene("GameOver");//Final stage will load the GameOver Scene
        }
        else if (other.gameObject.CompareTag("Goal_Level4"))
        {
            Time.timeScale = 0f;
            pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(true);
            pauseMenuUI.transform.Find("ResumeButton").transform.gameObject.SetActive(false);
            pauseMenuUI.SetActive(true);
            Debug.Log("touching goal");
            string DeathReason = "Goal_Level4";
            string GoalPosition = "Goal_Level4";
            string CurrentCharacter = "Goal_Level4";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            DataStorage.coin_count = 0;
            PlayerController.lastCheckPointPos = null;
            // SceneManager.LoadScene("GameOver");//Final stage will load the GameOver Scene
        }
    }
}
