using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonDetection : MonoBehaviour
{
    public EnemyController controller;

    public bool playerTeam = false;
    public bool detection = false;

    public int fireAspect = 2;
    public void OnCollisionEnter2D(Collision2D collision)
    {
    }
    //    if(!playerTeam)
    //    {
    //        if (collision.gameObject.tag == "PlayerBullet")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);
    //            Destroy(collision.gameObject);
    //        }
    //        if (collision.gameObject.tag == "PlayerArrow")
    //        {
    //            if(gameObject.name == "Head")
    //            {
    //                int damageToTake = int.Parse(collision.gameObject.name);
    //                controller.Damaged(damageToTake * 2);
    //                Destroy(collision.gameObject);
    //            }
    //            else
    //            {
    //                int damageToTake = int.Parse(collision.gameObject.name);
    //                controller.Damaged(damageToTake);
    //                Destroy(collision.gameObject);
    //            }
    //        }
    //        if (collision.gameObject.tag == "PlayerTranquilizer")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);
    //            controller.Tranquilizer();
    //            Destroy(collision.gameObject);
    //        }
    //        if (collision.gameObject.tag == "PlayerMelee")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);

    //            //extra money
    //            if(collision.gameObject.GetComponent<Flame>() == true)
    //            {
    //                if (collision.gameObject.GetComponent<Flame>().enchant)
    //                {
    //                    if (collision.gameObject.GetComponent<Flame>().enchant.enchants[4] == true)
    //                    {
    //                        controller.LootingEnchant();
    //                    }
    //                }
    //            }
    //            else
    //            {

    //            }
    //        }
    //        if (collision.gameObject.tag == "PlayerMeleeCritable")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Crit(damageToTake);

    //            //extra money
    //            if (collision.gameObject.GetComponent<Flame>() == true)
    //            {
    //                if (collision.gameObject.GetComponent<Flame>().enchant.enchants[4] == true)
    //                {
    //                    controller.LootingEnchant();
    //                }
    //            }
    //            else
    //            {

    //            }
    //        }

            
    //        if (collision.gameObject.tag == "PlayerSummoningStaff")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);

    //            if (controller.healthSystem.health <= 0)
    //            {
    //                controller.CreateSkeleton();
    //            }
    //        }
    //    }
    //    if(playerTeam)
    //    {
    //        if (collision.gameObject.tag == "EnemyBullet")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);
    //            Destroy(collision.gameObject);
    //        }
    //        if (collision.gameObject.tag == "Melee")
    //        {
    //            int damageToTake = int.Parse(collision.gameObject.name);
    //            controller.Damaged(damageToTake);
    //        }
    //    }

    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (detection)
    //    {
    //        if (collision.gameObject.tag == "Target")
    //        {
    //            controller.isInRage = false;
    //        }
    //    }

    //}

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (detection)
    //    {
    //        if (collision.gameObject.tag == "Target")
    //        {
    //            controller.isInRage = true;
    //        }
    //    }

    //    if(!playerTeam)
    //    {
    //        if(!detection)
    //        {
    //            if (collision.gameObject.tag == "PlayerFire")
    //            {
    //                fireAspect = 2;
    //                StartCoroutine(Fire(collision.gameObject));
    //            }

    //            if (collision.gameObject.tag == "PlayerFrost")
    //            {
    //                int damageToTake = int.Parse(collision.gameObject.name);
    //                controller.Damaged(damageToTake);
    //                controller.Frost();
    //                StartCoroutine(Frost(collision.gameObject));
    //            }
    //        }

    //    }




    //}

    //IEnumerator Fire(GameObject collision1)
    //{
    //        if(controller.healthSystem.health > 0 && fireAspect != 0)
    //        {
    //            int damageToTake = int.Parse(collision1.name);
    //            Destroy(collision1.GetComponent<BoxCollider2D>());
    //            controller.Damaged(damageToTake);
    //            yield return new WaitForSeconds(2);
    //            StartCoroutine(Fire(collision1));
    //            fireAspect = fireAspect - 1;
    //        }
    //        else
    //        {
    //            fireAspect = 0;
    //            Destroy(collision1.gameObject);
    //            fireAspect = 2;
    //            StopCoroutine(Fire(collision1));
    //        }


    //    if(fireAspect <= 0)
    //    {
    //        Destroy(collision1.gameObject);
    //        fireAspect = 2;
    //        StopCoroutine(Fire(collision1));
    //    }
    //}

    //IEnumerator Frost(GameObject collision2)
    //{
    //    bool destoryed = false;
    //    if(controller.healthSystem.health > 0 && collision2.gameObject != null && destoryed == false)
    //    {

    //        yield return new WaitForSeconds(3);
    //        destoryed = true;
    //        if (collision2.gameObject != null)
    //        {
    //            Destroy(collision2.gameObject.gameObject);
    //        }

    //        controller.touchForce = controller.savedForce;

    //    }


    //}
}
