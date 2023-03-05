using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeReward : MonoBehaviour
{
    [SerializeField] private float bonusTime = 1.0f;
    public delegate void TimeRewardDelegate(float time);
    public static TimeRewardDelegate timeRewardDelegate;
    private float timer = 0f;
    public float offsetTime = 1f;
    private bool isShow = false;

    public GameObject timepopDisplay;

    void start() {
        timepopDisplay.SetActive(false);
    }


    void Update()
    {
        if(isShow)
        {
            timer += Time.deltaTime;
            if(isShow == true)
            {
                if (timer > offsetTime) {
                    Debug.Log("Testing log for code");
                    timer = 0f;
                    timepopDisplay.SetActive(false);
                    isShow = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy(this.gameObject);
            timeRewardDelegate?.Invoke(bonusTime);

            isShow = true;
            timepopDisplay.SetActive(true);
        }
    }



}
