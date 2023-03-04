using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SendToGoogle stg;
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
            string DeathReason = "Goal_Level1";
            string GoalPosition = "Goal_Level1";
            string CurrentCharacter = "Goal_Level1";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            SceneManager.LoadScene("GameOver");
        } else if(other.gameObject.CompareTag("Goal_Tutorial1")){
            string DeathReason = "Goal_Tutorial1";
            string GoalPosition = "Goal_Tutorial1";
            string CurrentCharacter = "Goal_Tutorial1";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            SceneManager.LoadScene("Tutorial2");
        } else if(other.gameObject.CompareTag("Goal_Tutorial2")){
            string DeathReason = "Goal_Tutorial2";
            string GoalPosition = "Goal_Tutorial2";
            string CurrentCharacter = "Goal_Tutorial2";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            DataStorage.Deathcnt = 0;
            DataStorage.sessionID = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
