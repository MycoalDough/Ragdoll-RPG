using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blacksmith : MonoBehaviour
{
    public inGameCurrency currency;
    public int cost;

    public GameObject color;
    public TextMeshPro text;

    public bool canBuy = false;
    public GameObject buyDetection;
    public bool outOfStock = false;

    public int minCost, maxCost;

    public InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Awake()
    {
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();


        cost = Random.Range(minCost, maxCost);
        color.GetComponent<SpriteRenderer>().color = GetRandomColour32();

        buyDetection.SetActive(false);
       

        text.text = cost + " coins to repair item";

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
                        if (inventoryManager.firstWeapon != 0 || inventoryManager.secondWeapon != 0)
                        {
                            inventoryManager.UpdateText("Durability Fixed!");
                            currency.addCoins(-cost);

                            text.text = "I'm done repairing bye";
                            outOfStock = true;

                            if(inventoryManager.whichWeaponHolding == true)
                            {
                                int holdingNumber = inventoryManager.firstWeapon;
                                inventoryManager.weapons[holdingNumber].GetComponent<ToolDurability>().uses = inventoryManager.weapons[holdingNumber].GetComponent<ToolDurability>().maxUses;
                            }
                            else if(inventoryManager.whichWeaponHolding == false)
                            {
                                int holdingNumber = inventoryManager.secondWeapon;
                                inventoryManager.weapons[holdingNumber].GetComponent<ToolDurability>().uses = inventoryManager.weapons[holdingNumber].GetComponent<ToolDurability>().maxUses;
                            }
                            
                        }
                    }
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            canBuy = true;
            buyDetection.SetActive(true);
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
