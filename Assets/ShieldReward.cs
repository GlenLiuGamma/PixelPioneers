using UnityEngine;

public class ShieldReward : MonoBehaviour
{
    GameObject shield;
    void Start(){
        shield = GameObject.Find("Shield");
        if(shield == null){
            Debug.Log("NO");
        }
    }

    void Update(){
        if(shield == null){
            shield = GameObject.Find("Shield");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shield.SetActive(true);
            BasicPlayer.shieldTimeLeft = 5;
            Destroy(this.gameObject);
            // shield = 
            // shield = GameObject.Find("Shield");
            
            

        }
    }
}
