using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeList> upgradeList = new List<UpgradeList>();

    [Header("Config")]
    public Player player;
    public PlayerHealth ph;

    public bool gluttony = false;

    public bool gunslinger = false;
    public bool sharpenedTips = false;

    public bool shoplifter = false;
    public bool premiumQuality = false;
    public bool bankAccount = false;

    public bool bountiful;

    public GameObject marine;

    public bool rci;
    public bool rcii;

    public GameObject radiocommi;

    [Header("Upgraded Portals")]
    public bool up1;
    public bool up2;

    [Header("Clearance")]
    public bool clearance1;
    public bool clearance2;
    public void purchase(int choice)
    {
        if(choice == 0)
        {
            eatHealthy();
        }
        else if(choice == 1)
        {
            workout();
        }
        else if(choice == 2)
        {
            PremiumQuality();
        }
        else if (choice == 3)
        {
            sharpenedTipsUpgrade();
        }
        else if (choice == 4)
        {
            Gunslinger();
        }
        else if (choice == 5)
        {
            BankAccount();
        }
        else if (choice == 6)
        {
            Shoplifter();
        }
        else if (choice == 7)
        {
            upgradedPortalsI();
        }
        else if (choice == 8)
        {
            upgradedPortalsII();
        }
        else if (choice == 9)
        {
            clearanceI();
        }
        else if (choice == 10)
        {
            clearanceII();
        }
        else if(choice == 11)
        {
            Bountiful();
        }
        else if(choice == 12)//radiocommi
        {
            radiocommi.SetActive(true);
            rci = true;
        }
        else if(choice == 13)
        {
            rcii = true;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if(rcii)
        {
            Instantiate(marine, new Vector3(-30, 2), Quaternion.identity);
        }
    }

    public void Bountiful()
    {
        bountiful = true;
    }

    public void PremiumQuality()
    {
        premiumQuality = true;
    }

    public void BankAccount()
    {
        bankAccount = true;
    }


    public void eatHealthy() //increases HP by 10
    {
        ph.maxHealth += 10;
        ph.currentHealth += 10;
        gluttony = true;
    }

    public void workout() //increase all atributes 
    {
        player.movementSpeed += 50;
        ph.maxHealth += 5;
        ph.currentHealth += 5;
    }




    public void sharpenedTipsUpgrade()
    {
        sharpenedTips = true;
    }

    public void Gunslinger()
    {
        gunslinger = true;
    }

    public void Shoplifter()
    {
        shoplifter = true;
    }

    public void upgradedPortalsI()
    {
        up1 = true;
    }

    public void upgradedPortalsII()
    {
        up2 = true;
    }


    public void clearanceI()
    {
        clearance1 = true;
    }

    public void clearanceII()
    {
        clearance2 = true;
    }
}
