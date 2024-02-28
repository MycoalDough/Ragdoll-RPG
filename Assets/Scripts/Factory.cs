using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Factory : MonoBehaviour
{
    public GameObject[] array;
    public inGameCurrency currency;
    public int cost;
    public int objectToSell;

    public TextMeshPro text;
    public GameObject creationPoint;
    public FixedJoint2D fixedJoint2D;

    public bool canBuy = false;
    public GameObject buyDetection;
    public bool outOfStock = false;

    public GameObject lunge;

    public int minCost, maxCost;
    GameObject itemCreated;
    // Start is called before the first frame update
    void Awake()
    {
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();

        buyDetection.SetActive(false);
        objectToSell = Random.Range(0, array.Length);
        itemCreated = Instantiate(array[objectToSell], creationPoint.transform.position, array[objectToSell].transform.rotation);
        cost = Random.Range(minCost, maxCost);


        foreach (Transform child in itemCreated.transform)
        {
            child.gameObject.layer = 11;
            if(child.gameObject.GetComponent<Rigidbody2D>())
            {
                child.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            if(child.gameObject.name == "LungeDetection")
            {
                lunge = child.gameObject;
                lunge.SetActive(false);

            }

        }



        text.text = cost + " coins for robot";

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
                        currency.addCoins(-cost);
                        itemCreated.GetComponent<EnemyController>().start = true;
                        //itemCreated.GetComponent<PlayerBuddiesTm>().bought = true;
                        foreach (Transform child in itemCreated.transform)
                        {
                            child.gameObject.layer = 8;
                            if (child.gameObject.GetComponent<Rigidbody2D>())
                            {
                                child.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                            }

                            if(child.gameObject.name == "EnemyGun")
                            {
                                foreach (Transform child1 in child.gameObject.transform)
                                {
                                    if(child1.GetComponent<EnemyWeaponManager>())
                                    {
                                        child1.GetComponent<EnemyWeaponManager>().canShoot = true;
                                    }
                                    if(lunge)
                                    {
                                        lunge.SetActive(true);
                                    }
                                }

                            }
                        }

                        text.text = "we are creating new robots now bye";
                        outOfStock = true;
                    }
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            canBuy = true;
            buyDetection.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            canBuy = false;
            buyDetection.SetActive(false);
        }
    }
}
