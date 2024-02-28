using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeThrow : MonoBehaviour
{
    public bool touchPlayer = false;
    public float destoryAfterTime = 30f;

    public GameObject sporeEffect;
    public void Start()
    {
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, gameObject.GetComponent<Transform>().rotation.z);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(sporeEffect, gameObject.transform.position, sporeEffect.transform.rotation);
        Destroy(gameObject);
    }
}
