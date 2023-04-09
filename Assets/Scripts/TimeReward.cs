using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReward : MonoBehaviour
{

    [SerializeField] private float bonusTime = 1.0f;
    public delegate void TimeRewardDelegate(float time);
    public static TimeRewardDelegate timeRewardDelegate;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            timeRewardDelegate?.Invoke(bonusTime);
            DataStorage.coin_count += 1;

        }
    }
}
