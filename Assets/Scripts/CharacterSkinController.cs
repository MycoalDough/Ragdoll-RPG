using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinController : MonoBehaviour
{

    public string skin;
    public bool spawnItem = false;
    public GameObject player;
    public PlayerHealth ph;
    public Player plr;
    public InventoryManager inv;

    public Sprite box;

    public bool spawnINNow;

    public void Start()
    {
        InventoryManager inv = gameObject.GetComponent<InventoryManager>();

        if (!spawnItem)
        {
                StartCoroutine(debounce());
        }

        checkSkinNinja();
        checkHackerSkin();

    }

    public void checkSkinNinja()
    {
        if (skin == "Ninja")
        {
            plr.movementSpeed = 450;
            ph.currentHealth = 90;
            plr.jumpForce = 65;
            ph.maxHealth = 90;

            foreach (Transform child in player.transform.parent.transform)
            {
                if(child.GetComponent<SpriteRenderer>())
                {
                    child.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
                }

            }
        }


    }

    public void checkHackerSkin()
    {
        if(skin == "Hacker")
        {
            ph.currentHealth = 80;
            ph.maxHealth = 80;

            foreach (Transform child in player.transform.parent.transform)
            {
                HackerRandomColor r = child.gameObject.AddComponent<HackerRandomColor>();
                r.dmg = false;
                r.setArray = new Sprite[1];
                r.setArray[0] = box;
            }
        }
    }

    public void Update()
    {
        if(spawnINNow && !spawnItem)
        {
            if (skin == "Marksman")
            {
                spawnItemIn(6);
            }
            if (skin == "Giant")
            {
                spawnItemIn(5);
            }
            if (skin == "Ninja")
            {
                spawnItemIn(15);
                spawnItemIn(4);
            }

        }
    }

    public void spawnItemIn(int index)
    {
        Instantiate(inv.prefabs[index], player.transform.position, Quaternion.identity);
        spawnItem = true;
    }
    IEnumerator debounce()
    {
        yield return new WaitForSeconds(1.8f);
        spawnINNow = true;

    }
}
