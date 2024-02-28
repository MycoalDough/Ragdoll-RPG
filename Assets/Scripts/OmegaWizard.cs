using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmegaWizard : MonoBehaviour
{

    [Header("Main")]
    public int maxTime = 0;
    public float currentTime = 0f;
    public GameObject portal;
    public EnemyController enemyController;
    public bool startFight;
    public Animator anim;

    public Transform healthPot;

    public int currentAttack = 0;

    [Header("SummonSkeleton")]
    public Transform[] summonPos;
    public GameObject skeleton;
    public int timeForKnight;

    [Header("FireballShoot")]
    public GameObject[] fireballs;
    public Transform fireballSpawn;
    public int timeForLaser;

    [Header("Blind")]
    public GameObject blind;
    public int timeForBlind;

    [Header("Teleport")]
    public int timeForTeleport;


    [Header("Checkpoint")]
    public GameObject drop;
    bool canDrop = true;

    void Update()
    {

        currentTime = currentTime + Time.deltaTime;

        if (enemyController.isInRage)
        {
            startFight = true;
        }

        if (enemyController.gameObject.GetComponent<HealthAIManager>().healthSystem.health <= 1000)
        {
            if (canDrop)
            {
                Instantiate(drop, healthPot.position, Quaternion.identity);
                canDrop = false;
            }
        }
        if (enemyController.gameObject.GetComponent<HealthAIManager>().healthSystem.health <= 0)
        {
            portal.SetActive(true);
            Destroy(gameObject.GetComponent<OmegaWizard>());
        }


        //FIGHT
        if (startFight)
        {
            if (currentTime > maxTime)
            {
                int attack = Random.Range(1, 4);

                if (attack == 1)
                {
                    maxTime = timeForKnight;
                    currentTime = 0;
                    SummonKnight();
                }

                if (attack == 2)
                {
                    maxTime = timeForBlind;
                    currentTime = 0;
                    StartCoroutine(BlindAttack());
                }
                if (attack == 3)
                {
                    maxTime = timeForTeleport;
                    currentTime = 0;
                    Teleport();
                }
            }
        }
    }

    public void SummonKnight()
    {
        Instantiate(skeleton, summonPos[Random.Range(0, summonPos.Length)].position, Quaternion.identity);
    }

    public void Teleport()
    {
        gameObject.transform.position = summonPos[Random.Range(0, summonPos.Length)].position;

    }

    public void ShootLaser()
    {
        int direction = Random.Range(0, 3);

        Instantiate(fireballs[direction], fireballSpawn.position, fireballs[direction].transform.rotation);
    }

    IEnumerator BlindAttack()
    {
        blind.SetActive(true);
        yield return new WaitForSeconds(4);
        blind.SetActive(false);
    }
}
