using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelController : MonoBehaviour
{
    [Header("Walking")]
    public float steppingDistance;
    public Transform raycastPosL;
    public Transform raycastPosR;
    public Transform raycastPosM;

    public GameObject leftFoot;
    public GameObject rightFoot;
    public GameObject middleFoot;

    private RaycastHit2D targetL;
    private RaycastHit2D targetM;
    private RaycastHit2D targetR;
    private float distL;
    private float distM;
    private float distR;
    public float speed;
    public Vector2 targetPosL;
    public Vector2 targetPosM;
    public Vector2 targetPosR;

    [Header("Health")]
    public Transform pfhealthBar;
    public GameObject connection;
    public GameObject head;
    public int coinsOnDeath;
    public GameObject[] coins;

    [Header("Death")]
    public GameObject[] loseOnDeath;
    public int maxSkeletons = 0;
    public int maxCoins;
    public inGameCurrency deathCount;

    public HealthSystem healthSystem;
    public int maxHealth = 500;


    // Start is called before the first frame update
    void Start()
    {
        deathCount = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        coinsOnDeath = 10;
        healthSystem = new HealthSystem(maxHealth);
        healthSystem.health = healthSystem.healthMax;


        Transform Parent = connection.transform;
        Transform healthBarTransform = Instantiate(pfhealthBar, Parent);
        FixedJoint2D connectionPiece = healthBarTransform.GetComponent<FixedJoint2D>();
        connectionPiece.connectedBody = (head.gameObject.GetComponent<Rigidbody2D>());


        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }

    // Update is called once per frame
    void Update()
    {
        targetL = Physics2D.Raycast(raycastPosL.position, Vector2.down);
        targetR = Physics2D.Raycast(raycastPosR.position, Vector2.down);
        targetM = Physics2D.Raycast(raycastPosM.position, Vector2.down);



        targetPosL = new Vector2(targetL.point.x, targetL.point.y);
        targetPosR = new Vector2(targetR.point.x, targetR.point.y);
        targetPosM = new Vector2(targetM.point.x, targetM.point.y);



        distL = Vector2.Distance(leftFoot.transform.position, targetPosL);
        distR = Vector2.Distance(rightFoot.transform.position, targetPosR);
        distM = Vector2.Distance(middleFoot.transform.position, targetPosM);


        if (distL > steppingDistance)
        {
            //leftFoot.transform.position = targetPos;
            //leftFoot.GetComponent<WalkerLegController>().destroyJoint();
            leftFoot.transform.position = Vector2.MoveTowards(leftFoot.transform.position, targetPosL, speed * Time.deltaTime);
        }
        if (distR > steppingDistance)
        {
            //rightFoot.transform.position = targetPos;
            //rightFoot.GetComponent<WalkerLegController>().destroyJoint();

            rightFoot.transform.position = Vector2.MoveTowards(rightFoot.transform.position, targetPosR, speed * Time.deltaTime);
        }
        if (distM > steppingDistance)
        {
            //rightFoot.transform.position = targetPos;
            //rightFoot.GetComponent<WalkerLegController>().destroyJoint();

            middleFoot.transform.position = Vector2.MoveTowards(middleFoot.transform.position, targetPosM, speed * Time.deltaTime);
        }

        if (healthSystem.health <= 0)
        {
            Instantiate(coins[0], head.transform.position + new Vector3(0, 0, 0), Quaternion.identity);

            gameObject.AddComponent<Disable>().timeToDisable = 20;
            Destroy(gameObject.GetComponent<SentinelRaycastController>());

            foreach (Transform child in gameObject.transform)
            {

                child.gameObject.layer = 11;
                child.gameObject.tag = "Untagged";
                child.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                if (child.gameObject.GetComponent<EnemyArmController>() == true)
                {
                    Destroy(child.gameObject.GetComponent<EnemyArmController>());
                }
                if (child.gameObject.name == "HealthBar")
                {
                    Destroy(child.gameObject);
                }


                for (int i = 0; i < loseOnDeath.Length; i++)
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
                    }
                }

                Destroy(gameObject.GetComponent<SentinelController>());
            }
        }


    }

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
    private void onGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.onGameStateChanged -= onGameStateChanged;
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(3);
    }

    public void Heal(int healAmmount)
    {
        healthSystem.Damage(healAmmount);
    }

}
