using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public EnchantTool enchant;
    public GameObject fire;
    public bool flame = false;

    public UpgradeManager um;
    private bool umdb = false;
    [Header("Timer")]
    public float time = 0;
    public float maxTime = 2;
    public bool canFlame = false;
    public GameObject particle;

    [Header("MoneyEnchant")]
    public GameObject particleMoney;
    // Start is called before the first frame update

    public void Awake()
    {
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();

        if (um.sharpenedTips && !umdb)
        {
            umdb = true;
            gameObject.name = (int.Parse(gameObject.name)*1.1f).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!um)
        {
            um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
        }
        if (time < maxTime)
        {
            time = time + Time.deltaTime;

        }

        if (time >= maxTime && canFlame == false)
        {
            canFlame = true;
            time = 0;
        }


        if(enchant)
        {
            if (enchant.enchants[0] == true)
            {
                particle.SetActive(true);
                flame = true;
            }
            else if (enchant.enchants[0] == false)
            {
                particle.SetActive(false);
                flame = false;
            }

            if (enchant.enchants[4] == true)
            {
                particleMoney.SetActive(true);
            }
            else
            {
                particleMoney.SetActive(false);
            }
        }
        else
        {
            if(particle)
            {
                particle.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(flame && canFlame && collision.gameObject.layer == 10)
        {
            GameObject spawn = Instantiate(fire, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            spawn.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            canFlame = false;
            time = 0;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flame && canFlame && collision.gameObject.layer == 10)
        {
            GameObject spawn = Instantiate(fire, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            spawn.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            canFlame = false;
            time = 0;

        }
    }
}
