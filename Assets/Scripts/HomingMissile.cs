using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Rigidbody2D rb;
    public float rotateSpeed = 200f;

    [Header("Movement & AI")]
    private float distance;
    public Rigidbody2D RB;
    private float distanceToClosestPlayer;
    public string targTag;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        findClosestTarget();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
        }
    }

    private void Update()
    {
        if(target)
        {
            findClosestTarget();
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
                    target = player.transform;

                    if(target == null)
                    {
                        Destroy(gameObject.GetComponent<HomingMissile>());
                    }
                }
            }

        }

    }
}
