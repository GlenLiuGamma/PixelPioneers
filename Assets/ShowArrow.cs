using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    public GameObject Arrow;
    //public GameObject SquareMask;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Arrow.SetActive(true);
            //SquareMask.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Arrow.SetActive(false);
            //SquareMask.SetActive(true);
        }
    }
}
