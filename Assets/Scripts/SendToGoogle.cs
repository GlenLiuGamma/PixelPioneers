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
    [SerializeField] private string Level;

    // Start is called before the first frame update
    public GameObject player_control;
    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks;
        player_control = GameObject.Find("PlayerController");
        Debug.Log("_sessionID: " + _sessionID);
        Debug.Log("Death Count is: " + _eventCount);
        Debug.Log("Changing character count is: " + _eventCount);

    }


        private IEnumerator Post(string sessionID, string DeathCnt, string time, string TimeLeft, string DeathReason, string DeathPosition, string CurrentCharacter, string Level )

    {
    // Create the form and enter responses
    Debug.Log("In the script");
    WWWForm form = new WWWForm();
    /*
    SessionID: entry.1277992947
    Times of Remaining changing: entry.1776729504
    Time spent in game: entry.299018717
    amount of death: entry.909550211
    death reason: entry.1646797438
    death position: entry.69297460
    death character: entry.1912151537
    Level: entry.246051495

    */
    form.AddField("entry.1277992947", sessionID);
    form.AddField("entry.1776729504", TimeLeft);
    form.AddField("entry.299018717", time);
    form.AddField("entry.909550211", DeathCnt);
    form.AddField("entry.1646797438", DeathReason);
    form.AddField("entry.69297460", DeathPosition);
    form.AddField("entry.1912151537", CurrentCharacter);
    form.AddField("entry.246051495", Level);

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
    www.Dispose();
    }
    
    }
    public void Send(string DeathPosition, string DeathReason, string CurrentCharacter)
    {
     string Timeleft = "";
     PlayerController time_left = player_control.GetComponent<PlayerController>();
     Timeleft = time_left.timeLeft.ToString();
     StartCoroutine(Post(_sessionID.ToString(),  _eventCount.Deathcnt.ToString(), Time.time.ToString(), Timeleft, DeathReason, DeathPosition, CurrentCharacter, Level));

     /*
     1. Amount of time to switch characters - _eventCount.Timeleft
     2. Time to pass the level - Time.time

     3. Amount of death - fall into water:
     4. Amount of death - detected by the tower
     5. Amount of death - fall out of bound

     6. Amount of death - loss of all health

     7. Where does the player die? - transform.position

     
     */
    }
   

    // Update is called once per frame
    void Update()
    {
        /*  if (_eventCount.finish == true)
        {
            Send();
            //QuitGame();
        }  */
    }

    void OnApplicationQuit() {
        Debug.Log("Application ending after " + Time.time + " seconds");
        
    }

}
