using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public string nextLevel;
    public bool camera_pause;
    // Update is called once per frame
    void Start()
    {
        pauseMenuUI.transform.Find("NextLevel").transform.gameObject.SetActive(false);
        camera_pause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Entered");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
    }

    public void Resume()
    {
        camera_pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        camera_pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PlayerController.lastCheckPointPos = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Debug.Log("loading menu...");
        Time.timeScale = 1f;
        PlayerController.lastCheckPointPos = null;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void NextLevel()
    {
        Debug.Log("Load to next level");
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }
}