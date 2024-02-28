using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForRaise : MonoBehaviour
{
    public Animator anim;

    public inGameCurrency currency;
    public bool inRange;
    // Start is called before the first frame update
    void Awake()
    {
        inRange = false;
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currency.coins >= 5)
            {
                if(inRange)
                {
                    anim.Play("BridgeEnable");
                    currency.addCoins(-5);
                }

            }
        }
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
}
