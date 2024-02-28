using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerRaycastManager : MonoBehaviour
{
    [Header("Movement & AI")]
    public GameObject target;
    public float distance;
    public GameObject hips;
    public bool onRight;
    public Rigidbody2D RB;
    public bool inRange;
    public float distanceToClosestPlayer;
    public string targTag;
    public float touchForce;

    public Transform rayL;
    public Transform rayR;

    [Header("Range")]
    public bool canWalk = true;
    public bool useRange = false;
    public bool isInRange = false;
    public GameObject range;
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            if (isInRange)
            {
                if (target != null)
                {
                    distance = Vector2.Distance(target.transform.position, hips.transform.position);
                    if (target.transform.position.x < hips.transform.position.x)
                    {
                        onRight = true;
                    }
                    else { onRight = false; }

                    if (distance > 1)
                    {
                        inRange = false;
                        if (onRight)
                        {
                            if(!active)
                            {
                                StartCoroutine(moveRight());
                            }
                            RB.AddForce(Vector2.left * touchForce);
                        }
                        else
                        {
                            if(!active)
                            {
                                StartCoroutine(moveLeft());
                            }
                            RB.AddForce(Vector2.right * touchForce);

                        }
                    }
                }
                else
                {
                    findClosestTarget();
                }

            }
            else
            {

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
            }

        }

        IEnumerator moveLeft()
        {
            active = true;

            rayL.position = rayL.position + new Vector3(4f, 0);

            yield return new WaitForSeconds(1);
            rayL.position = rayL.position + new Vector3(0, 3);

            yield return new WaitForSeconds(1);
            rayL.position = rayL.position + new Vector3(0, -3);


            rayL.position = rayL.position + new Vector3(-4f, 0);

            rayR.position = rayR.position + new Vector3(4f, 0);

            yield return new WaitForSeconds(1);
            rayR.position = rayR.position + new Vector3(0, 3);
            yield return new WaitForSeconds(1);

            rayR.position = rayR.position + new Vector3(0, -3);

            rayR.position = rayR.position + new Vector3(-4f, 0);

            active = false;


        }

        IEnumerator moveRight()
        {
            active = true;
            rayL.position = rayL.position + new Vector3(-4f, 0);

            yield return new WaitForSeconds(1);
            rayL.position = rayL.position + new Vector3(0, 3);
            yield return new WaitForSeconds(1);
            rayL.position = rayL.position + new Vector3(0, -3);


            rayL.position = rayL.position + new Vector3(4f, 0);

            rayR.position = rayR.position + new Vector3(-4f, 0);

            yield return new WaitForSeconds(1);
            rayR.position = rayR.position + new Vector3(0, 3);
            yield return new WaitForSeconds(1);

            rayR.position = rayR.position + new Vector3(0, -3);

            rayR.position = rayR.position + new Vector3(4f, 0);

            active = false;
        }
    }
}
