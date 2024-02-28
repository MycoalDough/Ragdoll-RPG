using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour
{

    public GameObject[] popcorns;

    public float time;
    public int maxTime;

    public float minForce, maxForce;

    public int min, max;

    private void Awake()
    {
        maxTime = Random.Range(min, max + 1);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if(time > maxTime)
        {
            GameObject kernel = Instantiate(popcorns[Random.Range(0, popcorns.Length)], gameObject.transform.position, gameObject.transform.rotation);
            kernel.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-30, 30), Random.Range(45, 90)) * Random.Range(minForce, maxForce));
            Destroy(gameObject);
        }
    }
}
