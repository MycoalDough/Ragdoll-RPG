using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBush : MonoBehaviour
{

    public GameObject enemy;

    public GameObject head;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            enemy.SetActive(true);
            head.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5000);
            Destroy(gameObject);
        }
    }

}
