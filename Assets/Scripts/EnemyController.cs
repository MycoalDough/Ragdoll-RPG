using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Movement & AI")]
    public GameObject target;
    private float distance;
    public GameObject hips;
    public bool onRight;
    public Animator anim;
    public Rigidbody2D RB;
    public float touchForce = 6;
    public bool inRange;
    public float distanceToClosestPlayer;
    public string targTag;
    public float savedForce;
    private Vector2 savedVelocity;
    public float animationSpeed = 1f;

    [Header("Range")]
    public bool canWalk = true;
    public bool useRange = false;
    public bool isInRage = false;
    public bool start = true;
    public bool overide;
    [Header("Health")]
    public Transform pfhealthBar;
    public GameObject connection;
    public GameObject head;
    public int coinsOnDeath;
    public GameObject[] coins;

    [Header("Death")]
    public GameObject[] loseOnDeath;
    public GameObject skeleton;
    public int maxSkeletons = 0;
    public int maxCoins;
    public inGameCurrency deathCount;

    public HealthSystem healthSystem;
    public int maxHealth = 100;

    [Header("Quests")]
    public Quest quest;
    public void Start()
    {
        deathCount = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        savedForce = touchForce;
        if (anim)
        {
            anim.speed = animationSpeed;
        }
        //maxSkeletons = 0;
        //coinsOnDeath = Random.Range(0, maxCoins + 1);
        //healthSystem = new HealthSystem(maxHealth);
        //healthSystem.health = healthSystem.healthMax;


        //Transform Parent = connection.transform;
        //Transform healthBarTransform = Instantiate(pfhealthBar, Parent);
        //FixedJoint2D connectionPiece = healthBarTransform.GetComponent<FixedJoint2D>();
        //connectionPiece.connectedBody = (head.gameObject.GetComponent<Rigidbody2D>());


        //HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        //healthBar.Setup(healthSystem);
    }

    #region Functions
    //public void Crit(int damage)
    //{
    //    int rng = Random.Range(0, 7);

    //    if (rng == 2)
    //    {
    //        healthSystem.Damage(damage * 3);
    //    }
    //    else
    //    {
    //        healthSystem.Damage(damage);
    //    }
    //}

    //public void Damaged(int damage)
    //{
    //    healthSystem.Damage(damage);
    //}

    //public void LootingEnchant()
    //{
    //    if (maxCoins != 0)
    //    {
    //        int rdm = Random.Range(0, 3);

    //        if (rdm == 1)
    //        {
    //            Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
    //        }
    //    }

    //}
    //public void Frost()
    //{
    //    StartCoroutine(Freeze());
    //}
    private void onGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.onGameStateChanged -= onGameStateChanged;
    }

    //IEnumerator Freeze()
    //{
    //    touchForce = 0;
    //    yield return new WaitForSeconds(3);
    //    touchForce = savedForce;
    //}

    //public void Heal(int healAmmount)
    //{
    //    healthSystem.Damage(healAmmount);
    //}

    //public void CreateSkeleton()
    //{
    //    maxSkeletons++;

    //    if(maxSkeletons == 1)
    //    {
    //        Instantiate(skeleton, head.transform.position + new Vector3(0, 3, 0), skeleton.transform.rotation);
    //    }
    //}

    //public void Tranquilizer()
    //{
    //    StartCoroutine(tranq());
    //}

    //IEnumerator tranq()
    //{
    //    foreach (Transform child in gameObject.transform)
    //    {
    //        if (child.gameObject.GetComponent<Balance>() == true)
    //        {
    //            child.gameObject.GetComponent<Balance>().force = 0;
    //        }
    //    }
    //    touchForce = 0;

    //        yield return new WaitForSeconds(2);

    //    if(healthSystem.health > 0)
    //    {
    //        touchForce = savedForce;
    //        foreach (Transform child in gameObject.transform)
    //        {
    //            if (child.gameObject.GetComponent<Balance>() == true)
    //            {
    //                child.gameObject.GetComponent<Balance>().force = child.gameObject.GetComponent<Balance>().savedForce;
    //            }
    //        }
    //    }
    //}

    #endregion
    private void Update()
    {
        if(deathCount == null)
        {
            deathCount = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        }
        if(target == null)
        {
            findClosestTarget();

        }
        if (start)
        {
            findClosestTarget();

            if(Time.timeScale == 0)
            {
                savedVelocity = new Vector2(RB.gameObject.GetComponent<Rigidbody2D>().velocity.x, RB.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if(Time.time == 1)
            {
                RB.gameObject.GetComponent<Rigidbody2D>().velocity = savedVelocity;
            }
            if (canWalk)
            {
                if (isInRage)
                {
                    if(target != null)
                    {
                        distance = Vector2.Distance(target.transform.position, hips.transform.position);
                        if(!overide)
                        {
                            if (target.transform.position.x < hips.transform.position.x)
                            {
                                onRight = true;
                            }
                            else { onRight = false; }
                        }


                        if (distance > 1)
                        {
                            inRange = false;
                            if (onRight)
                            {
                                if (anim)
                                {
                                    anim.Play("Walk Back");

                                }
                                RB.AddForce(Vector2.left * touchForce);
                            }
                            else
                            {
                                if (anim)
                                {
                                    anim.Play("Walk");

                                }
                                RB.AddForce(Vector2.right * touchForce);
                            }
                        }
                    }
                    
                }
                else {
                    inRange = true; 
                    if(anim)
                    {
                        anim.Play("Idle");
                    }
                };

            }
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name + "entered sight, now chasing.");
        if(collision.gameObject.tag == "Target")
        {
            isInRage = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            isInRage = false;
        }
    }

    public void findClosestTarget()
            {
                {
                    distanceToClosestPlayer = Mathf.Infinity;
                    GameObject[] Players = GameObject.FindGameObjectsWithTag(targTag);
                    float distanceToPlayer;

                    foreach (GameObject player in Players)
                    {
                        distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;
                        if (distanceToPlayer < distanceToClosestPlayer)
                        {
                            distanceToClosestPlayer = distanceToPlayer;
                            target = player;
                        }
                    }
                }
                
            }

}