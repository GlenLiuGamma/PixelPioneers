using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using UnityEngine;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL;
    private long _sessionID;
    [SerializeField] private GameEvent _deathCount;
    // Start is called before the first frame update

    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks;
        Debug.Log("_sessionID: " + _sessionID);
        Debug.Log("Death Count is: " + _deathCount);
        Send();
    }


     private IEnumerator Post(string sessionID, string DeathCnt )
    {
    // Create the form and enter responses
    Debug.Log("In the script");
    WWWForm form = new WWWForm();
    form.AddField("entry.1545020692", sessionID);
    Debug.Log("Death count : " + _deathCount.Deathcnt);
    form.AddField("entry.316252562", DeathCnt);
    /* form.AddField("", testInt);
    form.AddField("", testBool);
    form.AddField("", testFloat); */
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
    /* // Assign variables
    _testInt = Random.Range(0, 101);
    _testBool = true;
    _testFloat = Random.Range(0.0f, 10.0f);
    StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(),
    _testBool.ToString(), _testFloat.ToString())); */
     StartCoroutine(Post(_sessionID.ToString(),  _deathCount.Deathcnt.ToString() ));
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
