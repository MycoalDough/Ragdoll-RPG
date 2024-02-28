using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawBuy : MonoBehaviour
{

    public CurrencyManager currency;
    public GameObject commonClawMachine;
    public GameObject lucky;
    public GameObject ethereal;

    public void buyCommonClaw()
    {
        if(currency.tokens >= 100)
        {
            currency.tokens = currency.tokens - 100;
            commonClawMachine.SetActive(true);
            commonClawMachine.GetComponent<ClawMachine>().PurchasedCommon();
        }
    }
    public void buyLuckyClaw()
    {
        if (currency.tokens >= 225)
        {
            currency.tokens = currency.tokens - 225;
            lucky.SetActive(true);
            lucky.GetComponent<ClawMachine>().PurchasedLucky();
        }
    }
    public void buyEtherealClaw()
    {
        if (currency.tokens >= 500)
        {
            currency.tokens = currency.tokens - 500;
            ethereal.SetActive(true);
            ethereal.GetComponent<ClawMachine>().PurchasedEthereal();
        }
    }
}
