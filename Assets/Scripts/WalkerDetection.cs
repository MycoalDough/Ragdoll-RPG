using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerDetection : MonoBehaviour
{
    public bool isDetection = false;
    public WalkerRaycastManager walkerRaycastManager;
    public Walker controller;
    public int fireAspect = 2;
    public float range;

    private void Update()
    {
        if(isDetection)
        {
            if (walkerRaycastManager)
            {
                //Debug.Log(enemy.target);
                float distanceFromTarget = Vector2.Distance(walkerRaycastManager.target.gameObject.transform.position, transform.position);
                if (distanceFromTarget < range)
                {
                    walkerRaycastManager.isInRange = true;
                }
                else
                {
                    walkerRaycastManager.isInRange = false;
                }
            }
            else
            {
                walkerRaycastManager = gameObject.GetComponentInParent<WalkerRaycastManager>();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            int damageToTake = int.Parse(collision.gameObject.name);
            controller.Damaged(damageToTake);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PlayerArrow")
        {
            {
                int damageToTake = int.Parse(collision.gameObject.name);
                controller.Damaged(damageToTake);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "PlayerTranquilizer")
        {
            int damageToTake = int.Parse(collision.gameObject.name);
            controller.Damaged(damageToTake);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PlayerMelee")
        {
            int damageToTake = int.Parse(collision.gameObject.name);
            controller.Damaged(damageToTake);

            //extra money
            if (collision.gameObject.GetComponent<Flame>() == true)
            {
                if (collision.gameObject.GetComponent<Flame>().enchant.enchants[4] == true)
                {
                    controller.LootingEnchant();
                }
            }
            else
            {

            }
        }
        if (collision.gameObject.tag == "PlayerMeleeCritable")
        {
            int damageToTake = int.Parse(collision.gameObject.name);
            controller.Crit(damageToTake);

            //extra money
            if (collision.gameObject.GetComponent<Flame>() == true)
            {
                if (collision.gameObject.GetComponent<Flame>().enchant.enchants[4] == true)
                {
                    controller.LootingEnchant();
                }
            }
            else
            {

            }
        }


        if (collision.gameObject.tag == "PlayerSummoningStaff")
        {
            int damageToTake = int.Parse(collision.gameObject.name);
            controller.Damaged(damageToTake);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isDetection)
        {
            if (collision.gameObject.tag == "PlayerFire")
            {
                fireAspect = 2;
                StartCoroutine(Fire(collision.gameObject));
            }

            if (collision.gameObject.tag == "PlayerFrost")
            {
                int damageToTake = int.Parse(collision.gameObject.name);
                controller.Damaged(damageToTake);
                controller.Frost();
                StartCoroutine(Frost(collision.gameObject));
            }
        }

    }

    IEnumerator Fire(GameObject collision1)
    {
        if (controller.healthSystem.health > 0 && fireAspect != 0)
        {
            int damageToTake = int.Parse(collision1.name);
            Destroy(collision1.GetComponent<BoxCollider2D>());
            controller.Damaged(damageToTake);
            yield return new WaitForSeconds(2);
            StartCoroutine(Fire(collision1));
            fireAspect = fireAspect - 1;
        }
        else
        {
            fireAspect = 0;
            Destroy(collision1.gameObject);
            fireAspect = 2;
            StopCoroutine(Fire(collision1));
        }


        if (fireAspect <= 0)
        {
            Destroy(collision1.gameObject);
            fireAspect = 2;
            StopCoroutine(Fire(collision1));
        }
    }

    IEnumerator Frost(GameObject collision2)
    {
        bool destoryed = false;
        if (controller.healthSystem.health > 0 && collision2.gameObject != null && destoryed == false)
        {

            yield return new WaitForSeconds(3);
            destoryed = true;
            if (collision2.gameObject != null)
            {
                Destroy(collision2.gameObject.gameObject);
            }
        }


    }
}
