using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2AI : MonoBehaviour
{

    [Header("Weapons")]
    public GameObject sword;
    public GameObject shield;
    public GameObject sniper;
    public GameObject nano;
    public Albowtross_Flight af;
    public GameObject flyMech;
    public GameObject cloudRod;
    public GameObject totemGO;

    public GameObject cloud;
    public float weaponSwapDB;
    public float weaponSwapDBCD;

    public float shieldCD = 1000;
    public bool shieldDB;
    public float runCD = 1000;
    public bool runDB;
    public bool canSwap;

    private bool firstHeal;

    public bool totem;


    public bool heal;

    public bool landed;
    public bool runAway;
    public InventoryManager im;

    [Header("Config")]
    //public float rangeTilFly;
    public float rangeTilLand;

    [Header("Script References")]
    public EnemyController ec;
    private HealthAIManager hm;


    // Start is called before the first frame update
    void Start()
    {
        im = GameObject.FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();

        hm = transform.parent.GetComponent<HealthAIManager>();
        ec = transform.parent.GetComponent<EnemyController>();
        StartCoroutine(spawnCloud());

    }

    IEnumerator spawnCloud()
    {
        yield return new WaitForSeconds(15);
        cloudRod.SetActive(true);
        GameObject i = Instantiate(cloud, transform.position, Quaternion.identity);
        if (ec.target.transform.position.x < gameObject.transform.position.x)
        {
            i.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 2000 * Time.deltaTime);
        }
        else
        {
            i.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000 * Time.deltaTime);
        }
        yield return new WaitForSeconds(5);
        cloudRod.SetActive(false);
        StartCoroutine(spawnCloud());
    }
    // Update is called once per frame
    void Update()
    {
        if(!runAway)
        {
            FlyAfter();
        }
        
        if(hm.healthSystem.health < 100)
        {
            if(totem)
            {
                totemGO.SetActive(true);
            }
        }
        else if(hm.healthSystem.health > 100)
        {
            runAndHeal();
        }

        if (hm.healthSystem.health >= 100 && landed && !runAway)
        {
            weaponSwapDB += Time.deltaTime;

            if(weaponSwapDB > weaponSwapDBCD)
            {
                weapons();
                weaponSwapDB = 0;
            }
        }

        if(hm.healthSystem.health < 50 && totem)
        {
            totem = false;
            totemGO.SetActive(false);
            hm.healthSystem.health = 700;
        }
    }

    public void weapons()
    {
        if (canSwap)
        {
            if(heal && hm.healthSystem.health < 800)
            {
                swapWeapon("nano");
            }

            if (im.whichWeaponHolding && im.weapons[im.firstWeapon].GetComponent<EnchantTool>().ranged && shieldCD > 500 && shieldDB)
            {
                shieldCD--;
                swapWeapon("shield");
            }
            else if (!im.whichWeaponHolding && im.weapons[im.secondWeapon].GetComponent<EnchantTool>().ranged && shieldCD > 500 && shieldDB)
            {
                shieldCD--;
                swapWeapon("shield");
            }
            else
            {
                shieldCD = shieldCD + 2f;
                swapWeapon("sword");
                StartCoroutine(coolDownShield());
            }
            StartCoroutine(checkIfSwitch());

        }

    }

    IEnumerator checkIfSwitch()
    {
        canSwap = false;
        yield return new WaitForSeconds(1);
        canSwap = true;
    }


    IEnumerator waitHeal()
    {
        yield return new WaitForSeconds(10);
        heal = true;
    }

    IEnumerator coolDownShield()
    {
        shieldDB = false;
        yield return new WaitForSeconds(5);
        shieldDB = true;
    }

    IEnumerator coolDownRun()
    {
        runDB = false;
        yield return new WaitForSeconds(5);
        runDB = true;
        firstHeal = false;
    }

    public void runAndHeal()
    {
        if (hm.healthSystem.health < 500 && runCD > 1000 && runDB)
        {
            Debug.Log("AAHHH");
            if(!firstHeal && hm.healthSystem.health < 300)
            {
                swapWeapon("nano");
                firstHeal = true;
            }
            swapWeapon("sniper");

            runCD = runCD - 0.05f;
            //Debug.Log(hm.healthSystem.health);
            runAway = true;
            ec.overide = true;
            if (ec.target.transform.position.x < gameObject.transform.position.x)
            {
                ec.onRight = false;
            }
            else
            {
                ec.onRight = true;
            }
        }
        else
        {
            runCD = runCD + 0.01f;
            ec.overide = false;
            runAway = false;
            if(runAway && runDB)
            {
                StartCoroutine(coolDownRun());
            }
        }
    }

    public void FlyAfter()
    {
        //Debug.Log(Vector3.Distance(transform.position, ec.target.transform.position));
        if (ec.target && Vector3.Distance(transform.position, ec.target.transform.position) < rangeTilLand)
        {

            af.enabled = false;
            landed = true;
            flyMech.SetActive(false);
            //swapWeapon("sniper");


        }
        else if (ec.target && (Vector3.Distance(transform.position, ec.target.transform.position) > (rangeTilLand * 5)))
        {
            Debug.Log(Vector3.Distance(transform.position, ec.target.transform.position));
            af.enabled = true;
            landed = false;
            flyMech.SetActive(false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            if (ec.target.transform.position.x < gameObject.transform.position.x)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            }
        }
        else
        {
            af.enabled = true;
            landed = false;
            flyMech.SetActive(true);
            swapWeapon("sniper");
        }
    }
    public void swapWeapon(string name)
    {
        if(name == "totem")
        {
            totemGO.SetActive(true);
        }
        else
        {
            totemGO.SetActive(false);
        }

        if (name == "sword")
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }

        if (name == "shield")
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }

        if (name == "sniper")
        {
            sniper.SetActive(true);
        }
        else
        {
            sniper.SetActive(false);
        }

        if (name == "nano")
        {
            heal = false;
            nano.SetActive(true);
            hm.healthSystem.Heal(50);
            StartCoroutine(waitHeal());
        }
        else
        {
            nano.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeTilLand);
    }
}
