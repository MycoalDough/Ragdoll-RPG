using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateFlareGun : MonoBehaviour
{
    public InventoryManager inv;
    public PlayerWeapons food;


    public bool inRange;
    public GameObject spawnItem;
    public GameObject pickup;

    public bool overwrite = false;
    public GameObject coin;

    public int itemRandom;
    void OnLevelWasLoaded(int level)
    {
        inv = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        food = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
    }
    // Start is called before the first frame update
    void Start()
    {
        parachute.SetActive(true);
        inv = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        food = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
    }


    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject weapon1 = inv.generateNewWeapon(true, 0);
                GameObject weapon2 = inv.generateNewWeapon(true, 0);

                Instantiate(pickup, gameObject.transform.position, pickup.transform.rotation);

                    Instantiate(weapon2, spawnItem.transform.position, Quaternion.identity);
                Instantiate(weapon1, spawnItem.transform.position, Quaternion.identity);
                Instantiate(food.items[Random.Range(0, food.items.Length)], spawnItem.transform.position, Quaternion.identity);
                Instantiate(food.items[Random.Range(0, food.items.Length)], spawnItem.transform.position, Quaternion.identity);
                Instantiate(food.items[Random.Range(0, food.items.Length)], spawnItem.transform.position, Quaternion.identity);
                Instantiate(coin, spawnItem.transform.position, Quaternion.identity);
                Instantiate(coin, spawnItem.transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
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
    public GameObject parachute;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        parachute.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.AddComponent<FixedJoint2D>().connectedBody = null;
    }
}
