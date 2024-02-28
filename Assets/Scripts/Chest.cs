using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public InventoryManager inv;
    public PlayerWeapons food;

    public bool needToBuy = false;
    public int cost = 15;
    public inGameCurrency IGC;
    public bool bought = false;

    public bool inRange;
    public GameObject spawnItem;
    public GameObject pickup;

    public bool overwrite = false;
    public GameObject coin;
    public int randomize = 0;
    public GameObject buyText;
    public bool golden = false;

    public int itemRandom;
    void OnLevelWasLoaded(int level)
    {
        inv = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        food = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
        IGC = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        generatePrefabs();

    }
    // Start is called before the first frame update
    void Start()
    {
        IGC = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        inv = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        food = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();

        generatePrefabs();
    }


    void generatePrefabs()
    {
        if(!overwrite)
        {
            randomize = Random.Range(1, 4);
        }

        //weapon
        if (randomize == 1)
        {
            itemRandom = Random.Range(1, inv.prefabs.Length);
        }
        //food
        if (randomize == 2)
        {
            itemRandom = Random.Range(0, food.items.Length);

        }
    }

    private void Update()
    {
        if(!IGC)
        {
            IGC = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();

        }
        if (inRange)
        {
            if(buyText)
            {
                if (needToBuy && !bought)
                {
                    buyText.SetActive(true);
                }
                else if (needToBuy && bought)
                {
                    buyText.SetActive(false);
                }
                else
                {
                    buyText.SetActive(false);
                }
            }
           

            if (Input.GetKeyDown(KeyCode.B))
            {
                if(!needToBuy)
                {
                    OpenChest();
                }
                else
                {
                    if(!bought)
                    {
                        if(IGC.coins >= cost)
                        {
                            bought = true;
                        }
                    }
                    else
                    {
                        OpenChest();
                    }
                }
            }
 
        }


    }

    public void OpenChest()
    {

            Instantiate(pickup, gameObject.transform.position, pickup.transform.rotation);
            if (randomize == 1)
            {
            GameObject newWeapon = inv.generateNewWeapon(true, 0);
                GameObject weaponClone = Instantiate(newWeapon, spawnItem.transform.position, Quaternion.identity);

                if (golden)
                {
                    for (int i = 0; i < weaponClone.GetComponent<ToolDurabilityDrop>().enchants.Length; i++)
                    {
                        int rng = Random.Range(1, 3);
                        if (rng == 2)
                        {
                            weaponClone.GetComponent<ToolDurabilityDrop>().enchants[i] = true;
                        }
                    }
                }
                Destroy(gameObject);
            }
            if (randomize == 2)
            {
                Instantiate(food.items[itemRandom], spawnItem.transform.position, Quaternion.identity);

                if (golden)
                {
                    itemRandom = Random.Range(0, food.items.Length);
                    Instantiate(food.items[itemRandom], spawnItem.transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            if (randomize == 3)
            {
                Instantiate(coin, spawnItem.transform.position, Quaternion.identity);
                Instantiate(coin, spawnItem.transform.position, Quaternion.identity);

                if (golden)
                {
                    Instantiate(coin, spawnItem.transform.position, Quaternion.identity);
                    Instantiate(coin, spawnItem.transform.position, Quaternion.identity);

                }
                Destroy(gameObject);
            }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            inRange = false;
            if (buyText)
            {
                buyText.SetActive(false);

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            inRange = true;

            if (needToBuy && !bought)
            {
                if (buyText)
                {
                    buyText.SetActive(true);

                }
            }
        }
    }
}
