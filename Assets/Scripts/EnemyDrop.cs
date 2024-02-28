using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{

    public List<EnemyDropVar> enemyDrop = new List<EnemyDropVar>();

    void Start()
    {

        //Debug.Log(enemyDrop.Count);

        for (int cnt = 0; cnt < enemyDrop.Count; cnt++)
        {
            //Debug.Log("Speed: " + enemyDrop[cnt].Speed + "  Enemy Action:" + enemyDrop[cnt].EnemyAction;
        }
    }

    private void Update()
    {
        if(!gameObject.GetComponent<Balance>())
        {
            for (int cnt = 0; cnt < enemyDrop.Count; cnt++)
            {
                float rng = Random.Range(0.00f, 2.00f);
                Debug.Log("Drop Rate: " + enemyDrop[cnt].enemyDropRate + " | RNG: "+ rng);
                if (rng < enemyDrop[cnt].enemyDropRate)
                {
                    Instantiate(enemyDrop[cnt].dropGameObject, transform.position, Quaternion.identity);
                }
                //Debug.Log("Speed: " + enemyDrop[cnt].Speed + "  Enemy Action:" + enemyDrop[cnt].EnemyAction;
            }
            this.enabled = false;
        }
    }
}