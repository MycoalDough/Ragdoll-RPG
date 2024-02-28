using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddForceDetection : MonoBehaviour
{
    public EnemyAddForce enemyAddForce;
    public float range;
    public EnemyController controller;
    public bool playerTeam = false;

    private void Update()
    {
        if(!controller)
        {
            if(GameObject.FindObjectOfType<EnemyController>())
            {
                controller = GameObject.FindObjectOfType<EnemyController>().GetComponent<EnemyController>();
            }
        }

        if(controller.target)
        {
            float distanceFromTarget = Vector2.Distance(controller.target.gameObject.transform.position, transform.position);
            if (distanceFromTarget < range)
            {
                if (enemyAddForce)
                {
                    enemyAddForce.isInRange = true;

                }
            }
            else
            {
                if (enemyAddForce)

                {
                    enemyAddForce.isInRange = false;

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
