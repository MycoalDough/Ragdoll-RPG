using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolDurability : MonoBehaviour
{
    public int uses;
    public int maxUses;
    public GameObject tool;

    public InventoryManager inventoryManager;
    public EnchantTool enchantTool;
    public TextMeshPro text;

    public void Awake()
    {
        enchantTool = gameObject.GetComponent<EnchantTool>();
        text.text = "Durability: " + uses;
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
        maxUses = uses;
    }

    private void OnEnable()
    {
        Durability(0);
    }
    public void Durability(int changeInt)
    {
        if(enchantTool.enchants[3] == true)
        {
            int random = Random.Range(0, 3);

            if(random == 0)
            {
                uses = uses - changeInt;
                text.text = "Durability: " + uses;
                if (uses <= 0)
                {
                    tool.SetActive(false);
                    uses = maxUses;

                    if (inventoryManager.whichWeaponHolding == true)
                    {
                        Debug.Log("First Weapon Destroyed");
                        inventoryManager.firstWeapon = 0;
                        inventoryManager.whichWeaponHolding = false;
                        inventoryManager.swapWeapon(1);
                    }
                    else if (inventoryManager.whichWeaponHolding == false)
                    {
                        Debug.Log("Second Weapon Destroyed");
                        inventoryManager.secondWeapon = 0;
                        inventoryManager.whichWeaponHolding = true;
                        inventoryManager.swapWeapon(0);
                    }
                }
            }
        }
        else
        {
            uses = uses - changeInt;
            text.text = "Durability: " + uses;
            if (uses <= 0)
            {
                tool.SetActive(false);
                uses = maxUses;

                if (inventoryManager.whichWeaponHolding == true)
                {
                    Debug.Log("First Weapon Destroyed");
                    inventoryManager.firstWeapon = 0;
                    inventoryManager.whichWeaponHolding = false;
                    inventoryManager.swapWeapon(1);
                }
                else if (inventoryManager.whichWeaponHolding == false)
                {
                    Debug.Log("Second Weapon Destroyed");
                    inventoryManager.secondWeapon = 0;
                    inventoryManager.whichWeaponHolding = true;
                    inventoryManager.swapWeapon(0);
                }
            }
        }
    }
}
