using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using UnityEngine;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL;
    private long _sessionID;
    [SerializeField] private GameEvent _eventCount;
    // Start is called before the first frame update

    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks;
        Debug.Log("_sessionID: " + _sessionID);
        Debug.Log("Death Count is: " + _eventCount);
        Debug.Log("Changing character count is: " + _eventCount);

    }


     private IEnumerator Post(string sessionID, string DeathCnt, string time, string AmtofChange )
    {
    // Create the form and enter responses
    Debug.Log("In the script");
    WWWForm form = new WWWForm();
    form.AddField("entry.1277992947", sessionID);
    form.AddField("entry.1776729504", DeathCnt);
    form.AddField("entry.909550211", time);
    form.AddField("entry.299018717", AmtofChange);
    // Send responses and verify result
    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
    {
    yield return www.SendWebRequest();
    if (www.result != UnityWebRequest.Result.Success)
    {
    Debug.Log(www.error);
    }
    else
    {
    Debug.Log("Form upload complete!");
    }
    }
    }
    public void Send()
    {
     StartCoroutine(Post(_sessionID.ToString(),  _eventCount.Deathcnt.ToString(), Time.time.ToString(), _eventCount.AmtofChange.ToString() ));
     #if UNITY_EDITOR
     UnityEditor.EditorApplication.isPlaying = false;
     #endif
     Application.Quit();
    }
   

    // Update is called once per frame
    void Update()
    {
         if (_eventCount.finish == true)
        {
            Send();
            //QuitGame();
        } 
    }

    void OnApplicationQuit() {
        Debug.Log("Application ending after " + Time.time + " seconds");
        
    }

    public void QuitGame()
    {
        Debug.Log("Finish the level");
        Send();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
