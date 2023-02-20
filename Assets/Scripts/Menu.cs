using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu: MonoBehaviour
{
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
}