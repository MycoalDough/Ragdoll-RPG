using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaBullet : MonoBehaviour
{
    [Header("Movement & AI")]
    public GameObject target;
    private float distance;
    public bool onRight;
    public Rigidbody2D RB;
    private float distanceToClosestPlayer;
    public string targTag;
    public bool rotateStart = false;
    public float force = 6000;
    public float moveSpeed = 10f;
    private GameObject player;



    void FixedUpdate()
    {
        findClosestTarget();

        if (player != null)
        {
            if(rotateStart == false)
            {
                Debug.Log("Rotated");
                rotateNow();
                rotateStart = true;


                Vector2 moveDir = (target.transform.position - transform.position).normalized * moveSpeed;
                RB.velocity = new Vector2(moveDir.x, moveDir.y);
            }
        }
    }

    void rotateNow()
    {
        if (!onRight)
        {
            Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 difference = playerpos - transform.position;
            float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
            RB.MoveRotation(Mathf.LerpAngle(RB.rotation, rotationZ, force * Time.fixedDeltaTime));
        }
        else
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, -vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * force);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Ragdoll>())
        {
            collision.gameObject.GetComponentInParent<Ragdoll>().RagdollLock();
        }
    }
}
