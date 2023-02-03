using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int waitSecond = 1;
    private float step;
    private Vector2 endPos;
    private Vector2 startPos;
    private Vector2 targetPos;
    public GameObject startpoint;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endPos = new Vector2(transform.position.x, transform.localScale.y/2-1 );
        startPos = new Vector2(transform.position.x, -transform.localScale.y+1);
        transform.position = startPos;
        //target = new Vector2(transform.position.x, transform.localScale.y/2);
        GameEvent.current.Death += onPlayerDeath;
        Debug.Log("The tower is set");
    }

    // Update is called once per frame

    private void onPlayerDeath()
    {
        Debug.Log("Trigger die event");
    }
    void Update()
    {
        StartCoroutine(Movement());
        
    }
    private IEnumerator Movement() {
        Vector2 currentPosition = transform.position;
        if (currentPosition == startPos) {
            yield return new WaitForSeconds (waitSecond);
            targetPos = endPos;
        }
        else if (currentPosition == endPos) {
            yield return new WaitForSeconds (waitSecond);
            targetPos = startPos;
        }
        step =  moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Die();
        } 
    }

    private void Die() {
        Debug.Log("The player is detected by the tower");
        GameEvent.current.DeathTriggerCount();
        Player.transform.position = startpoint.transform.position;
    }
}
