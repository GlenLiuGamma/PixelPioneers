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
        if (other.gameObject.CompareTag("Player"))
        {
            string DeathReason = "Goal";
            string GoalPosition = "Goal";
            string CurrentCharacter = "Goal";
            stg.Send(DeathReason, GoalPosition, CurrentCharacter);
            SceneManager.LoadScene("GameOver");
        }
    }
}
