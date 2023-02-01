using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{

    [SerializeField] GameObject[] rockPrefab;
    [SerializeField] float secondspawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rockspawn());
    }

    IEnumerator rockspawn() {
        while (true) {
            var wanted = Random.Range(minTras, maxTras);
            var pos = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(rockPrefab[Random.Range(0, rockPrefab.Length)],
            pos, Quaternion.identity);
            yield return new WaitForSeconds(secondspawn);
            Destroy(gameObject, 3f);
        }
    }
    // Update is called once per frame

}
