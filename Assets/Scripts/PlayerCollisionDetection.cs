using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{

    public InventoryManager manager;
    public PlayerHealth health;
    public inGameCurrency inGameCurrency;
    public RageBar rageBar;

    public GameObject balloon;

    public Player player;
    public void Awake()
    {
        inGameCurrency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        health = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        rageBar = GameObject.FindObjectOfType<RageBar>().GetComponent<RageBar>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BronzeCoin")
        {
            inGameCurrency.addCoins(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "SilverCoin")
        {
            Destroy(collision.gameObject);
            inGameCurrency.addCoins(3);
        }
        if (collision.gameObject.name == "GoldCoin")
        {
            Destroy(collision.gameObject);
            inGameCurrency.addCoins(5);
        }
        if (collision.gameObject.name == "DiamondCoin")
        {
            Destroy(collision.gameObject);
            inGameCurrency.addCoins(10);
        }

        if (manager.firstWeapon == 0 || manager.secondWeapon == 0)
        {
            if (collision.gameObject.name == "PlayerItem")
            {
                manager.collectWeapon(collision.gameObject.GetComponent<ToolDurabilityDrop>().number, collision.gameObject);
                collision.gameObject.SetActive(false);
            }
        }

        if(collision.gameObject.tag == "EnemyBullet")
        {
            float damageReduction = health.getRanged();
            int damageToTake = int.Parse(collision.gameObject.name);
            health.Damage(Mathf.RoundToInt(damageToTake / damageReduction));
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Melee")
        {
            float damageReduction = health.getMelee();
            int damageToTake = int.Parse(collision.gameObject.name);
            health.Damage(Mathf.RoundToInt(damageToTake / damageReduction));
        }
        if (collision.gameObject.tag == "PlayerHeal")
        {
            int healAmount = int.Parse(collision.gameObject.name);
            health.Heal(healAmount);


            if (collision.gameObject.GetComponent<SpeedPotion>())
            {
                collision.gameObject.layer = 11;
            }
            else if (collision.gameObject.GetComponent<ShieldPotion>())
            {
                collision.gameObject.layer = 11;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

        if(collision.gameObject.name == "Balloon10")
        {
            player.balloonCD(balloon, this.gameObject);
            health.Damage(10);
            rageBar.IncreaseRage(10);
        }

        if (collision.gameObject.tag == "ShadyMushroom")
        {
            int healAmount = int.Parse(collision.gameObject.name);
            health.Heal(healAmount);

            player.shady();
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "BlindnessBerry")
        {
            int healAmount = int.Parse(collision.gameObject.name);
            health.Heal(healAmount);

            player.blind();
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHeal")
        {
            int healAmount = int.Parse(collision.gameObject.name);
            health.Heal(healAmount);


            if (collision.gameObject.GetComponent<SpeedPotion>())
            {
                collision.gameObject.layer = 11;
            }
            else if (collision.gameObject.GetComponent<ShieldPotion>())
            {
                collision.gameObject.layer = 11;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Melee")
        {
            int damageToTake = int.Parse(other.gameObject.name);
            health.Damage(damageToTake);
        }
    }
}
