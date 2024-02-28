using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    public GameObject text;
    public bool collide;

    public UpgradeManager um;
    public bool shady = false;
    public bool blind = false;
    private void Start()
    {
        gameObject.transform.parent.tag = "Untagged";
        text.SetActive(false);
        gameObject.transform.parent.gameObject.layer = 11;
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "collideHeal")
        {
            collide = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            collide = false;
            text.SetActive(false);
        }
    }

    private void Update()
    {
        if(collide)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                gameObject.transform.parent.gameObject.layer = 10;
                if(shady)
                {
                    gameObject.transform.parent.tag = "ShadyMushroom";
                }
                else if (blind)
                {
                    gameObject.transform.parent.tag = "BlindnessBerry";
                }
                else
                {
                    gameObject.transform.parent.tag = "PlayerHeal";
                }
                if(um.gluttony)
                {
                    um.ph.maxHealth++;
                }
                Destroy(gameObject);
            }
        }
    }
}
