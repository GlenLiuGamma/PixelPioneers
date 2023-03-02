using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReward : MonoBehaviour
{
    [SerializeField] private float bonusTime = 1.0f;
    [SerializeField] private SendToGoogle _coinCount;//Need to drag GameManager object to coin
    public delegate void TimeRewardDelegate(float time);
    public static TimeRewardDelegate timeRewardDelegate;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            _coinCount.coin_count +=1;
            timeRewardDelegate?.Invoke(bonusTime);
        }
    }
}
