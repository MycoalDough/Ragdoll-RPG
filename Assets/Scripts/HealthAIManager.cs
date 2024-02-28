using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAIManager : MonoBehaviour
{
    [Header("Health")]
    public GameObject pfhealthBar;
    public GameObject connection;
    public GameObject head;
    public int coinsOnDeath;
    public GameObject[] coins;
    public float timeToDestroy = 20f;

    [Header("Death")]
    public GameObject[] loseOnDeath;
    public GameObject skeleton;
    public int maxSkeletons = 0;
    public int maxCoins;
    public inGameCurrency deathCount;
    public bool explodeOnDeath = false;

    public HealthSystem healthSystem;
    public int maxHealth = 100;

    public UpgradeManager um;
    private RadioCommsIManager rcim;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        deathCount = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        //rcim = GameObject.FindObjectOfType<RadioCommsIManager>().GetComponent<RadioCommsIManager>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();

        maxSkeletons = 0;
        coinsOnDeath = Random.Range(0, maxCoins + 1);
        if(um.bountiful)
        {
            coinsOnDeath++;

            if(coinsOnDeath > 10)
            {
                coinsOnDeath = 10;
            }
        }
        healthSystem = new HealthSystem(maxHealth);
        healthSystem.health = healthSystem.healthMax;
        if(!connection)
        {
            connection = transform.Find("HealthBar").gameObject;
        }
        if(!head)
        {
            head = transform.Find("Head").gameObject;
        }

        if (pfhealthBar == null)
        {
            pfhealthBar = Resources.Load("HealthBarPrefab") as GameObject;
        }
        Transform Parent = connection.transform;
        Transform healthBarTransform = Instantiate(pfhealthBar.transform, Parent);
        FixedJoint2D connectionPiece = healthBarTransform.GetComponent<FixedJoint2D>();
        connectionPiece.connectedBody = (head.gameObject.GetComponent<Rigidbody2D>());


        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }

    public void setUp()
    {
        pfhealthBar = Resources.Load("HealthBarPrefab") as GameObject;
        coins = new GameObject[4];
        coins[0] = Resources.Load("BronzeCoin") as GameObject;
        coins[1] = Resources.Load("SilverCoin") as GameObject;
        coins[2] = Resources.Load("GoldCoin") as GameObject;
        coins[3] = Resources.Load("DiamondCoin") as GameObject;
        skeleton = Resources.Load("Skeleton") as GameObject;
    }

    // Update is called once per frame
    public void Crit(int damage)
    {
        int rng = Random.Range(0, 7);

        if (rng == 2)
        {
            healthSystem.Damage(damage * 3);
        }
        else
        {
            healthSystem.Damage(damage);
        }
    }

    public void Damaged(int damage)
    {
        healthSystem.Damage(damage);

        if(rcim)
        {
            rcim.current += damage;
        }
    }

    public void LootingEnchant()
    {
        if (maxCoins != 0)
        {
            int rdm = Random.Range(0, 3);

            if (rdm == 1)
            {
                Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
        }

    }
    public void Frost()
    {
        StartCoroutine(Freeze());
    }


    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(3);
    }

    public void Heal(int healAmmount)
    {
        healthSystem.Damage(healAmmount);
    }

    public void CreateSkeleton()
    {
        maxSkeletons++;

        if (maxSkeletons == 1)
        {
            Instantiate(skeleton, head.transform.position + new Vector3(0, 3, 0), skeleton.transform.rotation);
        }
    }

    public void Tranquilizer()
    {
        StartCoroutine(tranq());
    }

    IEnumerator tranq()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.GetComponent<Balance>() == true)
            {
                child.gameObject.GetComponent<Balance>().force = 0;
            }
        }

        yield return new WaitForSeconds(2);

        if (healthSystem.health > 0)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Balance>() == true)
                {
                    child.gameObject.GetComponent<Balance>().force = child.gameObject.GetComponent<Balance>().savedForce;
                }
            }
        }
    }

    private void Update()
    {
        if (deathCount == null)
        {
            deathCount = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        }
        {

            if (healthSystem.health <= 0)
            {
                { //coins

                    if(gameObject.GetComponent<EnemyController>())
                    {
                        Destroy(gameObject.GetComponent<EnemyController>());
                    }
                    if (coinsOnDeath == 1)
                    {
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 2)
                    {
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 3)
                    {
                        Instantiate(coins[1], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 4)
                    {
                        Instantiate(coins[1], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 5)
                    {
                        Instantiate(coins[2], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 6)
                    {
                        Instantiate(coins[2], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 7)
                    {
                        Instantiate(coins[2], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 8)
                    {
                        Instantiate(coins[2], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[1], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    if (coinsOnDeath == 9)
                    {
                        Instantiate(coins[2], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[1], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);

                    }
                    if (coinsOnDeath == 10)
                    {
                        Instantiate(coins[3], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    }
                } //coins


                foreach (Transform child in gameObject.transform)
                {

                    child.gameObject.layer = 11;
                    child.gameObject.tag = "Untagged";

                    if (child.gameObject.GetComponent<Balance>() == true)
                    {
                        Destroy(child.gameObject.GetComponent<Balance>());
                    }
                    if (child.gameObject.GetComponent<EnemyArmController>() == true)
                    {
                        Destroy(child.gameObject.GetComponent<EnemyArmController>());
                    }
                    if (child.gameObject.name == "HealthBar")
                    {
                        Destroy(child.gameObject);
                    }

                    foreach (Transform child1 in child)
                    {
                        if (child1 != null)
                        {
                            foreach (var comp in child1.GetComponents<Component>())
                            {
                                if (comp is Animator)
                                {
                                    Destroy(comp);
                                }
                                if (!(comp is Transform))
                                {
                                    if (!(comp is BoxCollider2D))
                                    {
                                        if (!(comp is Rigidbody2D))
                                        {
                                            if (!(comp is SpriteRenderer))
                                            {
                                                if (!(comp is FixedJoint2D))
                                                {
                                                    if (!(comp is HingeJoint2D))
                                                    {
                                                        Destroy(comp);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if(explodeOnDeath && comp is HingeJoint2D)
                                {
                                    Destroy(comp);
                                }
                            }
                        }
                    }


                    for (int i = 0; i < loseOnDeath.Length; i++)
                    {
                        if(loseOnDeath[i])
                        {
                            loseOnDeath[i].gameObject.layer = 11;

                            foreach (var comp in loseOnDeath[i].GetComponents<Component>())
                            {
                                if (!(comp is Transform))
                                {
                                    if (!(comp is BoxCollider2D))
                                    {
                                        if (!(comp is Rigidbody2D))
                                        {
                                            if (!(comp is SpriteRenderer))
                                            {
                                                if (!(comp is FixedJoint2D))
                                                {
                                                    if (!(comp is HingeJoint2D))
                                                    {
                                                        Destroy(comp);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (explodeOnDeath && comp is HingeJoint2D)
                                {
                                    Destroy(comp);
                                }
                            }
                        }

                        
                    }
                }


                gameObject.AddComponent<Disable>().timeToDisable = timeToDestroy;
                deathCount.GainKill(1);
                Destroy(gameObject.GetComponent<HealthAIManager>());

            }
        }
    }
}