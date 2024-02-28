using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MutationSkin : MonoBehaviour
{
    public CharacterSkinController csc;
    public PlayerHealth ph;
    public Player player;

    [SerializeField] private bool stealthVal;
    public GameObject[] limbs;

    public GameObject siren;

    public GameObject mutationList;
    public GameObject mutationBar;
    public GameObject arm1;
    public GameObject arm2;

    public GameObject[] zombieClaws;
    public GameObject zombieJaw;

    public GameObject parasite;

    public Ragdoll rg;

    public GameObject homingMissile;
    public GameObject hmSpawn;

    public GameObject lunge1;
    public GameObject lunge2;
    public GameObject acidPoolGameObject;

    public GameObject[] clawFire;
    public GameObject[] fire;

    private bool start = true;

    [SerializeField] private int showing = 0;

    private bool ragdolled = false;

    public bool showingOptions = false;



    public int max;
    public float current;
    public float hard_mult;

    public Image slider;
    
    public void Start()
    {
        csc = gameObject.GetComponent<CharacterSkinController>();
        if(csc.skin != "Mutated")
        {
            mutationBar.SetActive(false);
            enabled = false;
        }
        else
        {
            lunge1.SetActive(true);
            lunge2.SetActive(true);

            showing = 0;

                arm1.name = 10 + "";
                arm1.tag = "PlayerMelee";
                arm2.tag = "PlayerMelee";
                arm1.layer = 14;
                arm2.layer = 14;
                arm2.name = 10 + "";
                ph.maxHealth = 70;
                mutationBar.SetActive(true);
                ph.currentHealth = 70;
                start = false;

        }
    }

    public void increase(int dmg)
    {
        current += dmg / 1.5f / hard_mult;
    }

    public void showOptions()
    {
        if(SceneManager.GetActiveScene().name != "Lobby")
        {
            mutationList.SetActive(true);
            showingOptions = true;
        }
        else
        {
            showingOptions = false;
        }


    }

    public void Update()
    {
        slider.fillAmount = current / 100;

        if (current >= 100)
        {
            current = 0;
            hard_mult += .3f;
            mutationList.SetActive(true);
            showingOptions = true;
        }

        if (showingOptions)
        {
            Time.timeScale = 0f;
        }
        if(ragdolled)
        {
            rg.ragdoll();
        }


        for (int i = 0; i < zombieClaws.Length; i++)
        {
            zombieClaws[i].name = Mathf.Round(ph.maxHealth / 2.3f).ToString();
        }
    }

    public void finish()
    {
        showingOptions = false;
        mutationList.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnLevelWasLoaded(int level)
    {

        if(enabled && SceneManager.GetActiveScene().name != "Lobby")
        {
            if (stealthVal)
            {
                StartCoroutine(stealthStart());
            }
            showing++;

            if (showing <= 1)
            {
                showOptions();
                showingOptions = true;
                showing = 0;
            }
        }

    }

    IEnumerator stealthStart()
    {
        yield return new WaitForSeconds(1f);
        EnemyRange[] ranges = FindObjectsOfType(typeof(EnemyRange)) as EnemyRange[];
        foreach (EnemyRange range in ranges) 
        {
            range.range = range.range / 1.5f;
        }

    }


    public void tough()
    {
        ph.maxHealth = ph.maxHealth + 10;
        ph.currentHealth = ph.currentHealth + 10;
        for (int i = 0; i < limbs.Length; i++)
        {
            int rng = Random.Range(1, 3);
            if (rng == 1)
            {
                Color tmp = limbs[i].GetComponent<SpriteRenderer>().color;
                tmp.g = tmp.g + Random.Range(2, 5);
                limbs[i].GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        finish();
    }

    public void speed()
    {
        player.movementSpeed = player.movementSpeed + 15; finish();
        for (int i = 0; i < limbs.Length; i++)
        {
            int rng = Random.Range(1, 3);
            if (rng == 1)
            {
                Color tmp = limbs[i].GetComponent<SpriteRenderer>().color;
                tmp.b = tmp.b - Random.Range(2, 5);
                tmp.r = tmp.r + Random.Range(1, 2);
                limbs[i].GetComponent<SpriteRenderer>().color = tmp;
            }
        }

    }

    public void reach()
    {
        for (int i = 3; i < 6; i++)
        {
            limbs[i].gameObject.transform.localScale = new Vector3(limbs[i].gameObject.transform.localScale.x, limbs[i].gameObject.transform.localScale.y * 1.17f);
        }
        for (int i = 0; i < limbs.Length; i++)
        {
            int rng = Random.Range(1, 3);
            if (rng == 1)
            {
                Color tmp = limbs[i].GetComponent<SpriteRenderer>().color;
                tmp.b = tmp.b - Random.Range(2, 5);
                tmp.r = tmp.r + Random.Range(2, 10);
                limbs[i].GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        finish();
    }

    public void mini()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            limbs[i].gameObject.transform.localScale = new Vector3(limbs[i].gameObject.transform.localScale.x * 0.9f, limbs[i].gameObject.transform.localScale.y * 0.9f);
        }
        finish();
    }

    public void enbiggen()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            limbs[i].gameObject.transform.localScale = new Vector3(limbs[i].gameObject.transform.localScale.x * 1.05f, limbs[i].gameObject.transform.localScale.y * 1.05f);
        }
        finish();
    }

    public void damage()
    {
        finish();
        arm1.name = (int.Parse(arm1.name) + 5) + "";
        arm1.name = (int.Parse(arm2.name) + 5) + "";
        for (int i = 0; i < limbs.Length; i++)
        {
            int rng = Random.Range(1, 3);
            if (rng == 1)
            {
                Color tmp = limbs[i].GetComponent<SpriteRenderer>().color;
                tmp.r = tmp.r + Random.Range(2, 7);
                limbs[i].GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }

    public void crawler()
    {
        finish();
        rg.ragdoll();
        player.movementSpeed = player.movementSpeed / 1.1f;
        player.jumpForce = player.jumpForce / 4;
        arm1.name = (int.Parse(arm1.name) + 10) + "";
        arm2.name = (int.Parse(arm2.name) + 10) + "";
        ragdolled = true;
    }

    public void jaw()
    {
        finish();
        zombieJaw.SetActive(true);
    }

    public void rocketArm()
    {
        finish();
        hmSpawn.SetActive(true);
        TeslaShoot HW = hmSpawn.AddComponent<TeslaShoot>();
        HW.bullet = homingMissile;
        HW.range = 23;
        HW.targTag = "Enemy";
        HW.fireRate = 9;
    }

    public void stealth()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            Color tmp = limbs[i].GetComponent<SpriteRenderer>().color;
            tmp.a = 0.7f;
            limbs[i].GetComponent<SpriteRenderer>().color = tmp;
            stealthVal = true;
            ph.maxHealth = ph.maxHealth - 5;
            ph.currentHealth = ph.currentHealth - 5;
            Debug.Log("Stealth: " + tmp);
        }
        finish();

    }

    public void acidPool()
    {
        finish();
        acidPoolGameObject.SetActive(true);
    }

    public void parasiteSpawn()
    {
        finish();
        parasite.SetActive(true);
    }
    
    public void claw()
    {
        finish();

        for (int i = 0; i < zombieClaws.Length; i++)
        {
            zombieClaws[i].SetActive(true);
        }
    }

    public void sirenActivate()
    {
        finish();

        siren.SetActive(true);
        ph.changedRanged(.1f);
        ph.changedMelee(.2f);
    }

    public void devil()
    {
        finish();

        ph.changedRanged(.3f);

        if(zombieClaws[0].gameObject.activeInHierarchy)
        {
            for (int i = 0; i < clawFire.Length; i++)
            {
                clawFire[i].SetActive(true);
                fire[i].SetActive(true);

            }
        }
        else
        {
            for (int i = 0; i < clawFire.Length; i++)
            {
                fire[i].SetActive(true);

            }
        }

    }
}
