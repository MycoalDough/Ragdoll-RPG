using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public inGameCurrency currency;
    public bool inRange = false;
    public Transform spawnPoint;
    public GameObject summon;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "collideHeal")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            inRange = false;
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currency.coins >= cost)
            {
                currency.addCoins(-cost);
                Instantiate(summon, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
