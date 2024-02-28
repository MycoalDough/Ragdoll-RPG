using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBoss : MonoBehaviour
{
    [Header("Main")]
    public int maxTime = 0;
    public float currentTime = 0f;
    public GameObject portal;
    public EnemyController enemyController;
    public bool startFight;
    public Animator anim;

    public int currentAttack = 0;

    [Header("SummonKnightAbility")]
    public Transform summonPos;
    public GameObject[] knights;
    public int timeForKnight;

    [Header("CelingLaer")]
    public GameObject[] lasers;
    public Transform laserSpawn;
    public int timeForLaser;

    [Header("Checkpoint")]
    public GameObject drop;
    bool canDrop = true;

    void Update()
    {

        currentTime = currentTime + Time.deltaTime;

        if(enemyController.isInRage)
        {
            startFight = true;
        }

        if(enemyController.gameObject.GetComponent<HealthAIManager>().healthSystem.health <= 1250)
        {
            if(canDrop)
            {
                Instantiate(drop, laserSpawn.position, Quaternion.identity);
                canDrop = false;
            }
        }
        if(enemyController.gameObject.GetComponent<HealthAIManager>().healthSystem.health <= 0)
        {
            portal.SetActive(true);
            Destroy(gameObject.GetComponent<KingBoss>());
        }


        //FIGHT
        if(startFight)
        {
            if(currentTime > maxTime)
            {
                int attack = Random.Range(1, 3);

                if(attack == 1)
                {
                    maxTime = timeForKnight;
                    currentTime = 0;
                    SummonKnight();
                }

                if(attack == 2)
                {
                    maxTime = timeForLaser;
                    currentTime = 0;
                    ShootLaser();
                }
            }
        }
    }

    public void SummonKnight()
    {
        int knightToSpawn = Random.Range(0, knights.Length);

        Instantiate(knights[knightToSpawn], summonPos.position, Quaternion.identity);
    }

    public void ShootLaser()
    {
        int direction = Random.Range(0, 2);

        Instantiate(lasers[direction], laserSpawn.position, lasers[direction].transform.rotation);
    }
}
