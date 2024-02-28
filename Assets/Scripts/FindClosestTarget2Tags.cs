using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestTarget2Tags : MonoBehaviour
{
    [Header("Movement & AI")]
    public GameObject target;
    public GameObject target2;
    private float distance;
    //public Rigidbody2D RB;
    private float distanceToClosestPlayer;
    private float distTo2ndClosePlayer;
    public string targTag;
    public GameObject player;
    public GameObject secondaryPlayer;


    private float dtcp;
    public string targTag2;

    public void Update()
    {
        findClosestTarget();
        //Debug.Log(player.transform.position);
    }

    private void Start()
    {
        findClosestTarget();

    }

    public void findClosestTarget()
    {
        distanceToClosestPlayer = Mathf.Infinity;
        GameObject[] Players = GameObject.FindGameObjectsWithTag(targTag);
        float distanceToPlayer;

        foreach (GameObject player in Players)
        {
            GameObject plr = player;
            //if (plr != gameObject || plr == null)
            {
                distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;
                if (distanceToPlayer < distanceToClosestPlayer)
                {
                    distanceToClosestPlayer = distanceToPlayer;
                    target = player;
                }
            }
        }

        //-----------------------------//

        distTo2ndClosePlayer = Mathf.Infinity;

        GameObject[] Players3 = GameObject.FindGameObjectsWithTag(targTag);
        float distanceToPlayer3;

        foreach (GameObject player3 in Players3)
        {
            GameObject plr1 = player3;
            if (plr1 != gameObject && plr1 != target || plr1 == null)
            {
                distanceToPlayer3 = (player3.transform.position - transform.position).sqrMagnitude;
                if (distanceToPlayer3 < distTo2ndClosePlayer)
                {
                    distTo2ndClosePlayer = distanceToPlayer3;
                    target = player;
                }
            }
        }

        if (targTag2 == "")
        {
            player = target;
        }
        else
        {
            //Debug.Log("test");
            dtcp = Mathf.Infinity;
            GameObject[] Players2 = GameObject.FindGameObjectsWithTag(targTag2);
            float distanceToPlayer2;

            foreach (GameObject player2 in Players2)
            {
                GameObject plr2 = player2;
                if(plr2 != gameObject)
                {
                    distanceToPlayer2 = (player2.transform.position - transform.position).sqrMagnitude;
                    if (distanceToPlayer2 < dtcp)
                    {
                        dtcp = distanceToPlayer2;
                        target2 = player2;
                    }
                }

            }
            if(target2 && target)
            {
                if (Vector3.Distance(target.transform.position, transform.position) > Vector3.Distance(target2.transform.position, transform.position))
                {
                    player = target2;
                }
                else
                {
                    player = target;
                }
            }
            else if(!target2)
            {
                player = target;
            }
            else if(!target)
            {
                player = target2;
            }
            else
            {
                player = null;
            }


        }
    }
}
