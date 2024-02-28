using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpgradeManagerCanvas : MonoBehaviour
{

    public int current;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI cost;

    public static string sLevelToLoad;

    public TextMeshProUGUI coins;
    public TextMeshProUGUI tickets;

    public GameObject canBuy;
    public GameObject cantBuy;
    public TextMeshProUGUI warning;

    public TextMeshProUGUI costOfTicket;
    //public Image image;

    private inGameCurrency gc;
    private UpgradeManager um;

    public void Start()
    {
        gc = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();

        if(um.clearance2)
        {
            costOfTicket.text = "Convert 17 Coins into 1 Ticket";
        }
        else
        {
            costOfTicket.text = "Convert 20 Coins into 1 Ticket";
        }
    }

    public void LoadScene()
    {
        Debug.Log(sLevelToLoad);
            SceneManager.LoadScene(sLevelToLoad);
    }

    private void Update()
    {
        coins.text = "Coins: " + gc.coins;
        tickets.text = "Tickets: " + gc.tickets;
    }
    public void exchangeToTicket()
    {
        if(um.clearance2)
        {
            if(gc.coins >= 17)
            {
                gc.coins = gc.coins - 17;
                gc.tickets++;
            }

        }
        else
        {
            if (gc.coins >= 20)
            {
                gc.coins = gc.coins - 20;
                gc.tickets++;
            }
        }
    }

    public void Change(int newNumber)
    {
        current = newNumber;
        warning.gameObject.SetActive(false);
        for (int i = 0; i < um.upgradeList.Count; i++)
        {
            if(um.upgradeList[i].indexNumber == newNumber)
            {
                nameText.text = um.upgradeList[i].name;
                descriptionText.text = um.upgradeList[i].description;
                cost.text = um.upgradeList[i].cost + " Tickets";

                if (um.upgradeList[i].bought)
                {
                    canBuy.SetActive(false);
                    cantBuy.SetActive(true);
                }
                else
                {
                    canBuy.SetActive(true);
                    cantBuy.SetActive(false);
                }

            }
        }
    }

    public void swapUpgradedPortals(int newNumber)
    {
        current = newNumber;
        for (int i = 0; i < um.upgradeList.Count; i++)
        {
            if (um.upgradeList[i].indexNumber == newNumber)
            {
                nameText.text = um.upgradeList[i].name;
                descriptionText.text = um.upgradeList[i].description;
                cost.text = um.upgradeList[i].cost + " Tickets";

                if(newNumber == 8) //-
                {
                    if(um.up1)
                    {
                        warning.gameObject.SetActive(false);
                        if (um.upgradeList[i].bought)
                        {
                            canBuy.SetActive(false);
                            cantBuy.SetActive(true);
                        }
                        else
                        {
                            canBuy.SetActive(true);
                            cantBuy.SetActive(false);
                        }
                    }
                    else
                    {
                        warning.gameObject.SetActive(true);
                        warning.text = "You need to buy Upgraded Portals I to unlock this.";
                        canBuy.SetActive(false);
                        cantBuy.SetActive(false);
                    }
                }
                else
                {
                    warning.gameObject.SetActive(false);

                    if (um.upgradeList[i].bought)
                    {
                        canBuy.SetActive(false);
                        cantBuy.SetActive(true);
                    }
                    else
                    {
                        canBuy.SetActive(true);
                        cantBuy.SetActive(false);
                    }
                }


            }
        }
    }


    public void swapRadioComms(int newNumber)
    {
        current = newNumber;
        for (int i = 0; i < um.upgradeList.Count; i++)
        {
            if (um.upgradeList[i].indexNumber == newNumber)
            {
                nameText.text = um.upgradeList[i].name;
                descriptionText.text = um.upgradeList[i].description;
                cost.text = um.upgradeList[i].cost + " Tickets";

                if (newNumber == 13) //-
                {
                    if (um.rci)
                    {
                        warning.gameObject.SetActive(false);
                        if (um.upgradeList[i].bought)
                        {
                            canBuy.SetActive(false);
                            cantBuy.SetActive(true);
                        }
                        else
                        {
                            canBuy.SetActive(true);
                            cantBuy.SetActive(false);
                        }
                    }
                    else
                    {
                        warning.gameObject.SetActive(true);
                        warning.text = "You need to buy Radio Comms I to unlock this.";
                        canBuy.SetActive(false);
                        cantBuy.SetActive(false);
                    }
                }
                else
                {
                    warning.gameObject.SetActive(false);

                    if (um.upgradeList[i].bought)
                    {
                        canBuy.SetActive(false);
                        cantBuy.SetActive(true);
                    }
                    else
                    {
                        canBuy.SetActive(true);
                        cantBuy.SetActive(false);
                    }
                }


            }
        }
    }


    public void swapClearance(int newNumber)
    {
        current = newNumber;
        for (int i = 0; i < um.upgradeList.Count; i++)
        {
            if (um.upgradeList[i].indexNumber == newNumber)
            {
                nameText.text = um.upgradeList[i].name;
                descriptionText.text = um.upgradeList[i].description;
                cost.text = um.upgradeList[i].cost + " Tickets";

                if (newNumber == 10) //-
                {
                    if (um.up1)
                    {
                        warning.gameObject.SetActive(false);
                        if (um.upgradeList[i].bought)
                        {
                            canBuy.SetActive(false);
                            cantBuy.SetActive(true);
                        }
                        else
                        {
                            canBuy.SetActive(true);
                            cantBuy.SetActive(false);
                        }
                    }
                    else
                    {
                        warning.gameObject.SetActive(true);
                        warning.text = "You need to buy Clearance I to unlock this.";
                        canBuy.SetActive(false);
                        cantBuy.SetActive(false);
                    }
                }
                else
                {
                    warning.gameObject.SetActive(false);
                    if (um.upgradeList[i].bought)
                    {
                        canBuy.SetActive(false);
                        cantBuy.SetActive(true);
                    }
                    else
                    {
                        canBuy.SetActive(true);
                        cantBuy.SetActive(false);
                    }
                }


            }
        }
    }

    public void Buy()
    {
        if (um.upgradeList[current].cost <= gc.tickets)
        {
            gc.tickets -= um.upgradeList[current].cost;
            um.upgradeList[current].bought = true;
            Change(current);
        }
    }
}
