using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enchanter : MonoBehaviour
{
    public inGameCurrency currency;
    public int cost;

    public GameObject color;
    public TextMeshPro text;
    public TextMeshPro warning;

    public bool canBuy = false;
    public GameObject buyDetection;
    public bool outOfStock = false;

    public UpgradeManager um;

    public int minCost, maxCost;

    public int enchant;
    public int maxEnchant;
    public PlayerWeapons weapons;

    public bool canRestock = false;

    public InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Awake()
    {
        weapons = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();

        enchant = Random.Range(0, weapons.enchants.Length);
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();

        cost = Random.Range(minCost, maxCost);
        color.GetComponent<SpriteRenderer>().color = GetRandomColour32();

        buyDetection.SetActive(false);


        text.text = cost + " coins to enchant item";
        if (um.clearance1)
        {
            cost = (int)(cost - cost * 0.2f);
            text.text = cost + " coins to enchant item (SALE)";
        }
        warning.text = "you will get the " + enchant + " enchantment";

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
                            if(!canRestock)
                            {
                                inventoryManager.UpdateText("Item successfully enchanted!");
                                currency.addCoins(-cost);

                                text.text = "enchanting done";
                                outOfStock = true;

                                if (inventoryManager.whichWeaponHolding == true)
                                {
                                    int holdingNumber = inventoryManager.firstWeapon;
                                    inventoryManager.weapons[holdingNumber].GetComponent<EnchantTool>().enchants[enchant] = true;
                                }
                                else if (inventoryManager.whichWeaponHolding == false)
                                {
                                    int holdingNumber = inventoryManager.secondWeapon;
                                    inventoryManager.weapons[holdingNumber].GetComponent<EnchantTool>().enchants[enchant] = true;
                                }
                            }
                            else if(canRestock)
                            {
                                inventoryManager.UpdateText("Item successfully enchanted!");
                                currency.addCoins(-cost);

                                cost = Random.Range(minCost, maxCost);
                                enchant = Random.Range(0, weapons.enchants.Length);
                                text.text = cost + " coins to enchant item";
                                warning.text = "you will get the " + enchant + " enchantment";

                                if (inventoryManager.whichWeaponHolding == true)
                                {
                                    int holdingNumber = inventoryManager.firstWeapon;
                                    inventoryManager.weapons[holdingNumber].GetComponent<EnchantTool>().enchants[enchant] = true;
                                }
                                else if (inventoryManager.whichWeaponHolding == false)
                                {
                                    int holdingNumber = inventoryManager.secondWeapon;
                                    inventoryManager.weapons[holdingNumber].GetComponent<EnchantTool>().enchants[enchant] = true;
                                }
                            }

                        }
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
