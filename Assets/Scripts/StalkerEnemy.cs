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

    [SerializeField]
    float acceleration;
    Rigidbody2D myRigidbody;
    // Update is called once per frame

<<<<<<< Updated upstream
    private float originalScale;

=======
    /*  private void OnCollisionEnter2D(Collision2D collision) {
         if (collision.gameObject.CompareTag("Player"))
         {

             collision.gameObject.transform.SetParent(transform);
             //collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
         }
     }
>>>>>>> Stashed changes
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    } */

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale.x;
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
            myRigidbody.velocity = new Vector2(movespeed, myRigidbody.velocity.y);
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        }
        else
        {
            //enemy is to the right side of the player, so move left
            myRigidbody.velocity = new Vector2(-movespeed, myRigidbody.velocity.y);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
    }


    void StopChasingPlayer()
    {
        if (myRigidbody.velocity.y == 0)
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y + myRigidbody.gravityScale * Time.deltaTime);
    }
}
