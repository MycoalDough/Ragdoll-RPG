using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantTool : MonoBehaviour
{
    //1 = fire (dot)
    //2 = frost (slow or freeze)
    //3 = rapid fire (faster shoot)
    //4 = unbreaking (50% chance of taking no durrability)
    //5 = income (extra money)
    //6 = adrenaline (speed boost and health on kill)

    [Header("Main")]
    public bool melee;
    public bool ranged;
    public GameObject weapon;
    public bool enchanted = false;
    public bool canBeFound = true;
    public GameObject changed;

    [Header("Enchants")]
    public PlayerWeapons pw;
    public GameObject durrabilityEffect;
    public bool[] enchants;

    private void OnLevelWasLoaded(int level)
    {
        pw = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();
    }

    public void Update()
    {
        if(enchants[3] == true)
        {
            durrabilityEffect.SetActive(true);
        }
        else
        {
            if(durrabilityEffect != null)
            {
                durrabilityEffect.SetActive(false);

            }
        }
    }
    public void Awake()
    {
        pw = GameObject.FindObjectOfType<PlayerWeapons>().GetComponent<PlayerWeapons>();

        enchants = new bool[pw.enchants.Length];
        
        weapon = gameObject;

        if(ranged)
        {
            foreach (Transform child in gameObject.transform)
            {
                if(child.gameObject.GetComponent<PlayerGunController>())
                {
                    changed = child.gameObject.GetComponent<PlayerGunController>().gameObject;
                }
            }
        }
    }

    public void changeEnchant(int enchant)
    {
        enchants[enchant] = true;
        enchanted = false;
    }
}
