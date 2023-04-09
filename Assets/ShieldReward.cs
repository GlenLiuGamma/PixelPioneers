using UnityEngine;

public class ShieldReward : MonoBehaviour
{
    [SerializeField] GameObject shield;
    void Start(){
        // shield = GameObject.Find("Shield");
        // while(shield == null){ 
        //     shield = GameObject.Find("Shield");
        //     Debug.Log("NO");
        // }
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
            if(shield == null){
                shield = GameObject.Find("Shield");
            }
            shield.SetActive(true);
            BasicPlayer.shieldTimeLeft = 5;
            Destroy(this.gameObject);
            // shield = 
            // shield = GameObject.Find("Shield");
            
            

        }
    }
}
