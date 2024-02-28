using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDropVar
{
    public float enemyDropRate;
    public GameObject dropGameObject;
    public EnemyDropVar(float EnemyDropRate, GameObject Drop)
    {
        enemyDropRate = EnemyDropRate;
        dropGameObject = Drop;

    }
}
