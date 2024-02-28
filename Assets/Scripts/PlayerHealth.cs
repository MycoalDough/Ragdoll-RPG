using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public float currentHealth;

    public GameObject player;
    public GameObject parent;
    public bool healCd;
    public bool dmgCd;

    public RageBar rageBar;
    public MutationSkin ms;
    public Image healthBar;
    public Player playerController;

    public UpgradeManager um;

    [SerializeField] private float meleeDamageReduction;
    [SerializeField] private float rangedDamageReduction;


    public EndScreen end;

    public float getMelee()
    {
        return meleeDamageReduction;
    }

    public float getRanged()
    {
        return rangedDamageReduction;
    }
    
    public void changedMelee(float byWhat)
    {
        meleeDamageReduction = meleeDamageReduction + byWhat;
    }

    public void changedRanged(float byWhat)
    {
        rangedDamageReduction = rangedDamageReduction + byWhat;
    }
    public void Start()
    {
        parent = gameObject;
        healthBar = GameObject.FindObjectOfType<HealthBarFind>().gameObject.GetComponent<Image>() ;
    }

    public void OnLevelWasLoaded(int level)
    {
        parent = gameObject;
        healthBar = GameObject.FindObjectOfType<HealthBarFind>().gameObject.GetComponent<Image>();
        end = GameObject.FindObjectOfType<EndScreen>().gameObject.GetComponent<EndScreen>();

        if(um.up1)
        {
            Heal(10);
        }

        if(um.up2)
        {
            Heal(20);
            maxHealth += 5;
        }
    }

    public void Update()
    {
        float fill;
        fill = currentHealth / 100;

        healthBar.fillAmount = currentHealth / maxHealth;

        if(!end)
        {
            end = GameObject.FindObjectOfType<EndScreen>().gameObject.GetComponent<EndScreen>();
        }
        if (currentHealth <= 0)
        {
            if ((gameObject.GetComponent<InventoryManager>().whichWeaponHolding == true && gameObject.GetComponent<InventoryManager>().firstWeapon == 20 || gameObject.GetComponent<InventoryManager>().whichWeaponHolding == false && gameObject.GetComponent<InventoryManager>().secondWeapon == 20))
            {
                if (gameObject.GetComponent<InventoryManager>().whichWeaponHolding)
                {
                    gameObject.GetComponent<InventoryManager>().firstWeapon = 0;
                    gameObject.GetComponent<InventoryManager>().whichWeaponHolding = false;
                    gameObject.GetComponent<InventoryManager>().swapWeapon(1);
                    currentHealth = maxHealth;
                }
                else if (gameObject.GetComponent<InventoryManager>().whichWeaponHolding == false)
                {
                    gameObject.GetComponent<InventoryManager>().secondWeapon = 0;
                    gameObject.GetComponent<InventoryManager>().whichWeaponHolding = true;
                    gameObject.GetComponent<InventoryManager>().swapWeapon(0);
                    currentHealth = maxHealth;
                }
            }
            else
            {
                StartCoroutine(death());
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    Destroy(parent); 
                    SceneManager.LoadScene(0);
                }
                foreach (Transform child in player.transform)
                {
                    if (child.gameObject.GetComponent<Balance>() == true)
                    {
                        Destroy(child.gameObject.GetComponent<Balance>());
                    }
                    if (child.gameObject.GetComponent<Player>() == true)
                    {
                        Destroy(child.gameObject.GetComponent<Player>());
                    }
                }
            }



        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(2);
        end.Finish();
    }
    public void Heal(int healthToHeal)
    {
        if(!healCd)
        {
            healCd = true;
            if (!(healthToHeal + currentHealth >= maxHealth))
            {
                currentHealth = healthToHeal + currentHealth;
            }
            else
            {
                currentHealth = maxHealth;
            }
            StartCoroutine(healCoolDown());
        }

    }
    public void Damage(int damage)
    {
        if (!dmgCd)
        {
            rageBar.IncreaseRage(damage);
            ms.increase(damage);
            dmgCd = true;
            if (playerController.ironSheild)
            {
                currentHealth = currentHealth - (damage / 2);

            }
            else
            {
                currentHealth = currentHealth - damage;
            }
            StartCoroutine(dmgCooldown());
        }

    }

    IEnumerator healCoolDown()
    {
        yield return new WaitForSeconds(0.05f);
        healCd = false;
    }

    IEnumerator dmgCooldown()
    {
        yield return new WaitForSeconds(0.05f);
        dmgCd = false;
    }
}
