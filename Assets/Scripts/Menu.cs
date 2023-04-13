using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu: MonoBehaviour
{

    public void start() {
        DataStorage.Deathcnt = 0;
        DataStorage.sessionID = 0;
        DataStorage.coin_count = 0;
    }
    
    public void ExitButton(){
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void Start_Tutorial1(){
        SceneManager.LoadScene("Tutorial1");
    }
    public void Start_Tutorial2(){
        SceneManager.LoadScene("Tutorial2");
    }
    public void Start_Level1(){
        SceneManager.LoadScene("SampleScene");
    }
    public void Start_Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Start_Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Start_Level4()
    {
        SceneManager.LoadScene("Level4");
    }
}