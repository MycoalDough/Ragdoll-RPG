using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public float range;
    public EnemyController enemy;

    public bool inRange;
    void Update()
    {
        if(enemy)
        {
            if(enemy.target)
            {
                //Debug.Log(enemy.target);
                float distanceFromTarget = Vector2.Distance(enemy.target.gameObject.transform.position, transform.position);
                if (distanceFromTarget < range)
                {
                    enemy.isInRage = true;
                    inRange = true;
                }
                else
                {
                    enemy.isInRage = false;
                    inRange = false;
                }
            }
           
        }
        else
        {
            enemy = gameObject.GetComponentInParent<EnemyController>();
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
