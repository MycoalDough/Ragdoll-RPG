using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaShoot : MonoBehaviour
{

    public GameObject bullet;
    public float range;

    public float fireRate;
    float time;

    public GameObject target;
    public string targTag;
    public float distanceToClosestPlayer;

    public bool homeOnPlayer = false;
    public bool parasite = false;
    public GameObject body;

    public PlayerHealth ph;
    public Player player;

    public int rotateSpeed;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findClosestTarget();
        if(target)
        {
            float distanceFromTarget = Vector2.Distance(target.gameObject.transform.position, transform.position);
            if (distanceFromTarget < range)
            {
                checkIfFire();
            }
        }

    }

    void checkIfFire()
    {
        time = time + Time.deltaTime;
        if(time > fireRate)
        {
            GameObject bulletClone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            if(homeOnPlayer)
            {
                bulletClone.GetComponent<Rigidbody2D>().AddForce(speed * Vector2.right);
            }

            if(parasite)
            {
                EnemyController p = bulletClone.GetComponent<EnemyController>();
                p.maxHealth = Mathf.RoundToInt(ph.maxHealth / 4);
                p.loseOnDeath[1].name = Mathf.RoundToInt(ph.maxHealth / 5).ToString();
                p.loseOnDeath[2].GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;

            }
            time = 0;
        }
    }

    //IEnumerator home(GameObject clone)
    //{
    //    if(homeOnPlayer)
    //    {
    //        Destroy(h);
    //    }
    //}
    void findClosestTarget()
    {
        {
            distanceToClosestPlayer = Mathf.Infinity;
            GameObject[] Players = GameObject.FindGameObjectsWithTag(targTag);
            float distanceToPlayer;

            foreach (GameObject player in Players)
            {
                distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;
                if (distanceToPlayer < distanceToClosestPlayer)
                {
                    distanceToClosestPlayer = distanceToPlayer;
                    target = player;
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
