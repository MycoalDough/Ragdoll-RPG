using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerRange : MonoBehaviour
{
    public float range;
    public WalkerRaycastManager enemy;

    void Update()
    {
        if (enemy.target)
        {
            //Debug.Log(enemy.target);
            float distanceFromTarget = Vector2.Distance(enemy.target.gameObject.transform.position, transform.position);
            if (distanceFromTarget < range)
            {
                enemy.isInRange = true;
            }
            else
            {
                enemy.isInRange = false;
            }
        }
        else
        {
            enemy = gameObject.GetComponentInParent<WalkerRaycastManager>();
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
