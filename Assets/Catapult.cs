using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject bullet;
    public float range;

    public float fireRate;
    public float time;

    public GameObject target;
    public string targTag;
    public float distanceToClosestPlayer;
    public GameObject spawnPos;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        findClosestTarget();
        if (target)
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
        if (time > fireRate)
        {
            time = 0;
            StartCoroutine(shoot());
        }
    }


    IEnumerator shoot()
    {
        anim.Play("Catapult",-1,0f);
        yield return new WaitForSeconds(1.57f);
        GameObject bulletClone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        bulletClone.GetComponent<LobShot>().target = target;
        bulletClone.GetComponent<LobShot>().spawnPos = spawnPos.transform;
    }

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
