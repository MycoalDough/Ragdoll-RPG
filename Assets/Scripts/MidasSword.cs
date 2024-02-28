using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidasSword : MonoBehaviour
{
    public inGameCurrency currency;
    public int baseDmg = 3;


    private void Awake()
    {
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currency == null)
        {
            currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        }

        int currDamage = Mathf.RoundToInt(baseDmg + (currency.coins / 3));
        gameObject.name = currDamage.ToString();
    }
}
