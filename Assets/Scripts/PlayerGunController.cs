using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    public GameObject bullet;

    public GameObject[] differentBullets;
    public int min, Max;

    public UpgradeManager um;


    public bool useRegularBullets = true;
    public GameObject shootSpot;
    public GameObject tranqulizerDart;
    public float speed = 50f;
    public Camera cam;

    public ToolDurability uses;

    public CharacterSkinController csc;
    public EnchantTool enchant;

    [Header("Timer")]
    public float maxTime;
    public float maxTimeRapidFire;
    public bool canShoot;
    private float time = 0;

    private bool gunDB = false; //gunslinger debounce

    public GameObject rapidFireParticle;
    public GameObject tranquilizerParticle;
    public GameObject homingParticle;

    public GameObject parentRanged;

    [Header("Bullet Spread")]
    public float RBS;
    public float minRBS, maxRBS;
    public int bulletsToShoot = 1;

    public void Start()
    {
        canShoot = false;
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        csc = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
        checkIfMarksman();

        homingParticle = Instantiate(parentRanged.transform.Find("AutoAim").gameObject, gameObject.transform.position, Quaternion.identity, this.transform);

        if(um.gunslinger && !gunDB)
        {
            gunDB = true;
            maxTime = maxTime / 1.2f;
            maxTimeRapidFire = maxTimeRapidFire / 1.2f;

        }
    }

    private void OnLevelWasLoaded(int level)
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        csc = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
        checkIfMarksman();

    }

    public void checkIfMarksman()
    {
        if(csc.skin == "Marksman")
        {
            minRBS = minRBS /3;
            maxRBS = minRBS/3;
        }
    }

    public void NormalBullet()
    {
        float RBS = Random.Range(minRBS, maxRBS);


        Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = shootSpot.transform.position;
        bulletClone.transform.rotation = Quaternion.Euler(mousePos);

        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.right.x, shootSpot.transform.right.y + RBS) * speed;

        if(enchant.enchants[6] == true)
        {
            int rng = Random.Range(0, 6);

            if(rng == 1)
            {
                bulletClone.AddComponent<HomingMissile>();
                HomingMissile h = bulletClone.GetComponent<HomingMissile>();
                h.targTag = "Enemy";
                h.speed = speed / 4;
                h.rotateSpeed = 500;
                h.RB = bulletClone.GetComponent<Rigidbody2D>();
            }
        }
    }
    
    public void traqDart()
    {
        float RBS = Random.Range(minRBS, maxRBS);

        Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

        GameObject bulletClone = Instantiate(tranqulizerDart);
        bulletClone.transform.position = shootSpot.transform.position;
        bulletClone.transform.rotation = Quaternion.Euler(mousePos);

        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.right.x, shootSpot.transform.right.y + RBS) * speed;
    }
    
    public void RNGBullet()
    {
        int rngBul = Random.Range(min, Max + 1);
        float RBS = Random.Range(minRBS, maxRBS);


        if (rngBul == min)
        {
            Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

            GameObject bulletClone = Instantiate(differentBullets[0]);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(mousePos);

            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.right.x, shootSpot.transform.right.y + RBS) * speed;
        }
        else
        {
            Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

            GameObject bulletClone = Instantiate(differentBullets[Random.Range(1, differentBullets.Length)]);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(mousePos);

            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.right.x, shootSpot.transform.right.y + RBS) * speed;
        }
    }
    public void Shoot()
    {
        float RBS = Random.Range(minRBS, maxRBS);

        for (int i = 0; i < bulletsToShoot; i++)
        {
            if (useRegularBullets)
            {

                if (enchant.enchants[5] == true)
                {
                    int rng = Random.Range(0, 6);

                    if (rng == 2)
                    {
                        traqDart();
                    }
                    else
                    {
                        NormalBullet();
                    }
                }
                else
                {
                    NormalBullet();
                }
            }

            else if(!useRegularBullets)
            {
                if (enchant.enchants[5] == true)
                {
                    int rng = Random.Range(0, 6);

                    if (rng == 2)
                    {
                        traqDart();
                    }
                    else
                    {
                        RNGBullet();

                    }
                }
                else //TURRET ONLY
                {
                    //TURRET ONLY
                    RNGBullet();
                }
            }
            else
            {
                TurretShoot();
            }
        }
       


    }

    public void TurretShoot()
    {
        int rngBul = Random.Range(min, Max + 1);

        if (rngBul == min)
        {
            Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

            GameObject bulletClone = Instantiate(differentBullets[0]);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(mousePos);

            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.up.x, shootSpot.transform.up.y + RBS) * speed;
        }
        else
        {
            Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

            GameObject bulletClone = Instantiate(differentBullets[Random.Range(1, differentBullets.Length)]);
            bulletClone.transform.position = shootSpot.transform.position;
            bulletClone.transform.rotation = Quaternion.Euler(mousePos);

            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpot.transform.up.x, shootSpot.transform.up.y + RBS) * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(cam == null)
        {
            cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        }
        time = time + Time.deltaTime;

        if(enchant)
        {
            if (enchant.enchants[2] == true)
            {
                rapidFireParticle.SetActive(true);

                if (time > maxTimeRapidFire && !canShoot)
                {
                    time = 0;
                    canShoot = true;
                }
            }
            else if (enchant.enchants[2] == false)
            {
                rapidFireParticle.SetActive(false);

                if (time > maxTime && !canShoot)
                {
                    time = 0;
                    canShoot = true;
                }
            }

            if (enchant.enchants[5] == true)
            {
                tranquilizerParticle.SetActive(true);
            }
            else if (enchant.enchants[5] == false)
            {
                tranquilizerParticle.SetActive(false);
            }


            if (enchant.enchants[6] == true)
            {
                homingParticle.SetActive(true);
            }
            else if (enchant.enchants[6] == false)
            {
                homingParticle.SetActive(false);
            }
        }


        if (Input.GetKey(KeyCode.E))
        {
            if(canShoot)
            {
                Shoot();
                uses.Durability(1);
                canShoot = false;
            }
        }
    }
}
