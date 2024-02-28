using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautController : MonoBehaviour
{
    [Header("Main")]
    public int maxTime = 0;
    public float currentTime = 0f;
    public GameObject portal;
    public EnemyController enemyController;
    public bool startFight;
    public Animator anim;
    public HealthAIManager hp;

    public Transform healthPot;

    public int currentAttack = 0;

    [Header("Boulder")]
    public float yLevel;
    public float minX, maxX;
    public GameObject[] boulders;
    public int timeForBoulder;

    [Header("Shockwave")]
    public GameObject shockwave;
    public Transform shockwaveSpawn;
    public int timeForShockwave;

    [Header("Enrage")]
    public GameObject enrageEffect;
    public int timeForEnraged;

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

        if (hp.healthSystem.health <= 1000)
        {
            if (canDrop)
            {
                Instantiate(drop, healthPot.position, Quaternion.identity);
                canDrop = false;
            }
        }
        if (hp.healthSystem.health <= 0)
        {
            portal.SetActive(true);
            Destroy(gameObject.GetComponent<JuggernautController>());
        }


        //FIGHT
        if (startFight)
        {
            if (currentTime > maxTime)
            {
                int attack = Random.Range(1, 4);

                if (attack == 1)
                {
                    maxTime = timeForBoulder;
                    currentTime = 0;
                    summonBoulders();
                }

                if (attack == 2)
                {
                    maxTime = timeForShockwave;
                    currentTime = 0;
                    spawnShockwave();
                }
                if (attack == 3)
                {
                    maxTime = timeForEnraged;
                    currentTime = 0;
                    StartCoroutine(enraged());
                }
            }
        }
    }

    public void summonBoulders()
    {
        int spawns = Random.Range(0, 20);

        for (int i = 0; i < spawns; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), yLevel);
            Instantiate(boulders[Random.Range(0, boulders.Length)], spawnPos, Quaternion.identity);
        }
    }

    public void spawnShockwave()
    {
        GameObject shockwaveSummon = Instantiate(shockwave, shockwaveSpawn.position, Quaternion.identity);

        if(gameObject.GetComponent<EnemyController>().onRight)
        {
            shockwaveSummon.GetComponent<Shockwave>().left = true;
        }
        else
        {
            shockwaveSummon.GetComponent<Shockwave>().left = false;
        }
    }

    IEnumerator enraged()
    {
        enrageEffect.SetActive(true);
        enrageEffect.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<HealthAIManager>().Heal(50);
        gameObject.GetComponent<EnemyController>().touchForce = 11;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<EnemyController>().touchForce = 8;
        enrageEffect.SetActive(false);
    }
}
