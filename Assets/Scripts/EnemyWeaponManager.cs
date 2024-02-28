using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public bool isGun = true;
    public GameObject bullet;
    public GameObject shootSpot;
    //public bool useTrigger = true;
    public bool canShoot = false;
    public Transform arm;
    public Vector3 armPos;
    public float speed = 50f;

    public EnemyController enemyController;
    public bool useEnemyController = true;

    public WalkerRaycastManager walker;
    public bool useWalkerRaycast;

    public float range;

    public bool parasite = false;

    //public bool isEnemy = true;

    public bool useRandom = false;
    public GameObject[] randomBullet;
    public bool shootRight = true;
    [Header("Timer")]
    public float maxTime;
    private float time = 0;
    public bool debug = false;
    public bool stopWalking = true;


    public void Start()
    {
        if(enemyController)
        {
            enemyController.canWalk = true;
        }
        canShoot = true;
    }

    // Start is called before the first frame update

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(useTrigger)
    //    {
    //        if(isEnemy)
    //        {
    //            if (collision.gameObject.tag == "Target")
    //            {
    //                if (enemyController)
    //                {
    //                    enemyController.canWalk = false;
    //                }
    //                canShoot = true;
    //            }
    //        }
    //        else
    //        {
    //            if (collision.gameObject.tag == "Enemy")
    //            {
    //                if (enemyController)
    //                {
    //                    enemyController.canWalk = false;
    //                }
    //                canShoot = true;
    //            }
    //        }

    //    }

    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(useTrigger)
    //    {
    //        if (isEnemy)
    //        {
    //            if (collision.gameObject.tag == "Target")
    //            {
    //                if (enemyController)
    //                {
    //                    enemyController.canWalk = true;
    //                }
    //                canShoot = false;
    //            }
    //        }
    //        else
    //        {
    //            if (collision.gameObject.tag == "Enemy")
    //            {
    //                if (enemyController)
    //                {
    //                    enemyController.canWalk = true;
    //                }
    //                canShoot = false;
    //            }
    //        }
    //    }

    //}



    public void Update()
    {

        
        if(useEnemyController)
        {
            if (enemyController)
            {
                if(enemyController.target)
                {
                    float distanceFromTarget = Vector2.Distance(enemyController.target.gameObject.transform.position, transform.position);

                    if (distanceFromTarget < range)
                    {
                        canShoot = true;
                        if(stopWalking)
                        {
                            enemyController.canWalk = false;

                        }
                    }
                    else
                    {
                        canShoot = false;
                        if (stopWalking)
                        {
                            enemyController.canWalk = true;

                        }

                    }

                }
                else
                {
                    enemyController.findClosestTarget();
                }

            }

        }
        else if(useWalkerRaycast)
        {
            if (walker.target)
            {
                float distanceFromTarget = Vector2.Distance(walker.target.gameObject.transform.position, transform.position);
                if (distanceFromTarget < range)
                {
                    canShoot = true;
                    walker.canWalk = false;
                }
                else
                {
                    canShoot = false;
                    walker.canWalk = true;

                }
            }

        }




        armPos = new Vector3(0, 0, arm.eulerAngles.z);


        if (enemyController && enemyController.gameObject.GetComponent<HealthAIManager>())
        {
            if (enemyController.gameObject.GetComponent<HealthAIManager>().healthSystem.health <= 0)
            {
                Destroy(gameObject);
            }
        }


            if (canShoot)
            {
                time = time + Time.deltaTime;

                if (time > maxTime)
                {
                    time = 0;
                    Shoot();
                }
            }


    }

    public void Shoot()
    {
        if(useRandom)
        {
            GameObject bulletClone = Instantiate(randomBullet[Random.Range(0, randomBullet.Length)]);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(armPos);

            if (shootRight)
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.right * speed;
            }
            else
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.up * speed;
            }
        }
        else
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(armPos);


            if (shootRight)
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.right * speed;
            }
            else
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.up * speed;
            }
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
