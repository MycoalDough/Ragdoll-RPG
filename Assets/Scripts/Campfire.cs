using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    //fireplace

    public bool destroyAfterTime;
    public float destroyAfterThisTime;

    public bool lit;
    public GameObject fireParticle;
    private PlayerHealth ph;

    private inGameCurrency cm;
    public GameObject openText;
    public bool bought;

    public bool healCD = false;

    public void Awake()
    {
        ph = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        cm = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();

    }
    public void Update()
    {
        if (destroyAfterTime && lit)
        {
            StartCoroutine(destroyAT());
            destroyAfterTime = false;
        }

        if(lit)
        {
            fireParticle.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            if (!lit && !bought)
            {
                openText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (cm.coins >= 16)
                    {
                        cm.coins = cm.coins - 16;
                        lit = true;
                        bought = true;
                        openText.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            openText.SetActive(false);

        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (lit)
        {
            if (healCD == false)
            {
                if (collision.gameObject.tag == "collideHeal")
                {
                    StartCoroutine(heal(0.5f));

                }
            }
        }

        if (!lit && !bought)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (cm.coins >= 16)
                {
                    cm.coins = cm.coins - 16;
                    lit = true;
                    bought = true;
                    openText.SetActive(false);
                }
            }
        }
    }


    IEnumerator heal(float time)
    {
        healCD = true;
        yield return new WaitForSeconds(time);
        ph.Heal(1);
        healCD = false;
    }

    IEnumerator destroyAT()
    {
        yield return new WaitForSeconds(destroyAfterThisTime);
        Destroy(gameObject);
    }
}
