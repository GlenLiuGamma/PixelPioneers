using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StalkerEnemy : MonoBehaviour
{
    [SerializeField]
    Transform player;
    //GameObject face;
    //Animator faceAnimator;
    [SerializeField]
    float movespeed;

    [SerializeField]
    float argoRange;
    Rigidbody2D myRigidbody;
    // Update is called once per frame
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < argoRange)
        {
         ChasePlayer(); 
        }
        else
        {
         StopChasingPlayer();
        }

        

    }
    void ChasePlayer()
        {
            if (transform.position.x < player.position.x)
            {
                //enemy is to the left side of the player, so move right
                myRigidbody.velocity = new Vector2(movespeed, 0);
                transform.localScale = new Vector2(transform.localScale.x,transform.localScale.y);
            }
            else
            {
                //enemy is to the right side of the player, so move left
                myRigidbody.velocity = new Vector2(-movespeed, 0);
                transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
            }
        }


        void StopChasingPlayer()
        {
            myRigidbody.velocity = new Vector2(0,0);
        }
}
