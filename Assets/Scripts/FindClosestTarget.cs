using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestTarget : MonoBehaviour
{
    [Header("Movement & AI")]
    public GameObject target;
    private float distance;
    public Rigidbody2D RB;
    private float distanceToClosestPlayer;
    public string targTag;
    public GameObject player;
    public int index = 1;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        findClosestTarget();
    }

    void findClosestTarget()
    {
        {
            int ind = 0;
            distanceToClosestPlayer = Mathf.Infinity;
            GameObject[] Players = GameObject.FindGameObjectsWithTag(targTag);
            float distanceToPlayer;

            foreach (GameObject player in Players)
            {
                GameObject plr = player;

                if(plr != gameObject)
                {
                    ind++;
                    distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;
                    if (distanceToPlayer < distanceToClosestPlayer)
                    {
                        if(ind == index)
                        {
                            distanceToClosestPlayer = distanceToPlayer;
                            target = player;
                        }

                    }
                }

            }
            player = target;

        }

    }
}
