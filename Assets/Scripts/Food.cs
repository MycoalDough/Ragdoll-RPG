using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public PlayerWeapons array;
    public inGameCurrency currency;
    public int cost;
    public int objectToSell;

    public GameObject color;
    public GameObject color2;
    public TextMeshPro text;
    public GameObject creationPoint;
    public FixedJoint2D fixedJoint2D;

    public bool canBuy = false;
    public GameObject buyDetection;
    public bool outOfStock = false;

    public UpgradeManager um;

    public int minCost, maxCost;
    GameObject itemCreated;
    // Start is called before the first frame update
    void Awake()
    {
        array = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();

        color.GetComponent<SpriteRenderer>().color = GetRandomColour32();
        color2.GetComponent<SpriteRenderer>().color = color.GetComponent<SpriteRenderer>().color;

        buyDetection.SetActive(false);
        objectToSell = Random.Range(0, array.items.Length);
        itemCreated = Instantiate(array.items[objectToSell], creationPoint.transform.position, array.items[objectToSell].transform.rotation, creationPoint.transform);
        cost = Random.Range(minCost, maxCost);
        itemCreated.layer = 11;
        fixedJoint2D = itemCreated.AddComponent<FixedJoint2D>();

        text.text = cost + " coins for food";
        if (um.clearance1)
        {
            cost = (int)(cost - cost * 0.2f);
            text.text = cost + " coins for food (SALE)";
        }

    }
    private Color32 GetRandomColour32()
    {
        //using Color32
        return new Color32(
          (byte)UnityEngine.Random.Range(0, 255), //Red
          (byte)UnityEngine.Random.Range(0, 255), //Green
          (byte)UnityEngine.Random.Range(0, 255), //Blue
          255 //Alpha (transparency)
        );
    }

    private void Update()
    {
        if (canBuy)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (!outOfStock)
                {
                    if (currency.coins >= cost)
                    {
                        Destroy(fixedJoint2D);
                        if(um.shoplifter)
                        {
                            int rng = Random.Range(1, 101);
                            if(rng < 94)
                            {
                                currency.addCoins(-cost);
                            }
                        }
                        else
                        {
                            currency.addCoins(-cost);
                        }
                        itemCreated.layer = 0;
                        text.text = "we out of food";
                        outOfStock = true;
                    }
                }
            }
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            buyDetection.SetActive(true);
            canBuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            canBuy = false;
            buyDetection.SetActive(false);
        }
    }
}
