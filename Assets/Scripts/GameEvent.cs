using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameEvent current;
    public int Deathcnt = 0;
    public void Awake() 
    {
        current = this;
    }

    public event Action Death;
    public void DeathTriggerCount() 
    {
        if (Death != null)
        {
            Debug.Log("Death count is " + Deathcnt);
            Deathcnt += 1;
            Death();
        }
    }
}
