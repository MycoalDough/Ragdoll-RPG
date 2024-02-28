using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsTarget : MonoBehaviour
{

    [Header("Movement & AI")]
    public GameObject target;
    private float distance;
    public bool onRight;
    public Rigidbody2D RB;
    private float distanceToClosestPlayer;
    public string targTag;

    public float force = 6000;
    private GameObject player;
    public bool isBallista = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        findClosestTarget();

        if (player != null)
        {
            if(!onRight)
            {
                Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 difference = playerpos - transform.position;
                float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
                RB.MoveRotation(Mathf.LerpAngle(RB.rotation, rotationZ, force * Time.fixedDeltaTime));
            }
            else if(onRight)
            {
                Vector3 vectorToTarget = target.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, -vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * force);
            }
            else if(isBallista)
            {
                Vector3 vectorToTarget = target.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, -vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, -Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * force);
            }

        }
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
            player = target;

        }

    }
}
