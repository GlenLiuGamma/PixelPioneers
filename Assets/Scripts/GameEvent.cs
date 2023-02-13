using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameEvent current;
    public int Deathcnt = 0;
    public int AmtofChange = 0;

    public bool finish = false;
    public void Awake() 
    {
        current = this;
    }

    public event Action Death;
    public event Action ChangeCharacter;
    public event Action FinishLevel;
    public void DeathTriggerCount() 
    {
        if (Death != null)
        {
            Deathcnt += 1;
            Debug.Log("Death count is " + Deathcnt);
            Death();
        }
    }

     public void ChangeCharacterTrigger() {
        if (ChangeCharacter != null)
        {
            AmtofChange += 1;
            Debug.Log("number of changing character is : " + AmtofChange);
            ChangeCharacter();
        }
    } 

    public void FinishTrigger() {
        if (FinishLevel != null) {
            finish = true;
            FinishLevel();
        }
    }
}
