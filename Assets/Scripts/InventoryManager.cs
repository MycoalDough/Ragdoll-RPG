using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] weapons;

    public GameObject[] prefabs;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public Camera cam;
    public GameObject shootSpot;
    public float speed = 50f;
    public TextMeshPro durability;

    public bool whichWeaponHolding = true; //one is true, two is false
    public int firstWeapon;
    public int secondWeapon;
    public CharacterSkinController characterSkinController;
    private void OnLevelWasLoaded(int level)
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        characterSkinController = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
        text1 = GameObject.Find("ItemText").gameObject.GetComponent<TextMeshProUGUI>();
        text2 = GameObject.Find("ItemText2").gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        characterSkinController = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        text1 = GameObject.Find("ItemText").gameObject.GetComponent<TextMeshProUGUI>();
        text2 = GameObject.Find("ItemText2").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public GameObject generateNewWeapon(bool randomize, int overwrite)
    {
        GameObject randomWeapon;
        GameObject newover;
        int rng = Random.Range(0, prefabs.Length);
        if (randomize)
        {
            randomWeapon = prefabs[rng];
        }
        else
        {
            newover = prefabs[overwrite];
            return newover;
            
        }
        bool correct = false;

        while(correct == false)
        {
            //Debug.Log("test");
            rng = Random.Range(0, prefabs.Length);
            if (weapons[rng].gameObject.GetComponent<EnchantTool>().canBeFound == true)
            {
                if (characterSkinController.skin == "Marksman")
                {
                    if (weapons[rng].gameObject.GetComponent<EnchantTool>().ranged == true)
                    {
                        correct = true;
                        randomWeapon = prefabs[rng];
                    }
                    else
                    {
                        correct = false;
                    }
                }
                else if (characterSkinController.skin == "Giant" || characterSkinController.skin == "Berserker")
                {
                    if (weapons[rng].gameObject.GetComponent<EnchantTool>().melee == true)
                    {
                        correct = true;
                        randomWeapon = prefabs[rng];
                    }
                    else
                    {
                        correct = false;
                    }
                }
                else
                {
                    correct = true;
                }
            }

        }

        randomWeapon = prefabs[rng];
        return randomWeapon;


        
    }
    void Update()
    {
        text1.text = "" + firstWeapon;
        text2.text = "" + secondWeapon;

        if (whichWeaponHolding == true && firstWeapon == 0 || whichWeaponHolding == false && secondWeapon == 0)
        {
            durability.text = "";
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if((whichWeaponHolding == true && firstWeapon != 0 || whichWeaponHolding == false && secondWeapon != 0))
            {
                if(whichWeaponHolding)
                {
                    Throw(prefabs[firstWeapon]);
                    firstWeapon = 0;
                    whichWeaponHolding = false;
                    swapWeapon(1);
                }
                else if (whichWeaponHolding == false)
                {
                    Throw(prefabs[secondWeapon]);
                    secondWeapon = 0;
                    whichWeaponHolding = true;
                    swapWeapon(0);
                }

                //holding = false;

                //isHolding = 0;
                //for (int i = 0; i < weapons.Length; i++)
                //{
                //    weapons[i].SetActive(false);
                //}
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(firstWeapon != 0)
            {
                whichWeaponHolding = true;
                //Debug.Log("Weapon Switched");
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[firstWeapon].SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!whichWeaponHolding && firstWeapon != 0)
            {
                whichWeaponHolding = true;
               // Debug.Log("Weapon Switched");
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[firstWeapon].SetActive(true);
            }
            else if (whichWeaponHolding && secondWeapon != 0)
            {
                whichWeaponHolding = false;
               // Debug.Log("Weapon Switched");
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[secondWeapon].SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(secondWeapon != 0)
            {
                whichWeaponHolding = false;
                //Debug.Log("Weapon Switched");
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[secondWeapon].SetActive(true);
            }
        }
    }

    public void swapWeapon(int weapon)
    {
        if(weapon == 0) //swap to one
        {
            if(firstWeapon != 0)
            {
                whichWeaponHolding = true;
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[firstWeapon].SetActive(true);
            }

        }
        else if(weapon == 1)
            if (secondWeapon != 0)
            {
                whichWeaponHolding = false;
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[secondWeapon].SetActive(true);
            }

    }

    public void Throw(GameObject weapon)
    {
        if(whichWeaponHolding == true) //if holding one or two
        {
            if(firstWeapon != 0) //if not null
            {
                swapWeapon(1); //swap to two
                whichWeaponHolding = false; //change hand
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false); //set all other objects to false
                }
                weapons[secondWeapon].SetActive(true);

                Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

                GameObject bulletClone = Instantiate(weapon);
                bulletClone.transform.position = shootSpot.transform.position;
                Vector3 armPos = new Vector3(0, 0, shootSpot.transform.rotation.z); 
                bulletClone.transform.rotation = Quaternion.Euler(armPos);

                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.up * speed;

                bulletClone.GetComponent<ToolDurabilityDrop>().uses = weapons[firstWeapon].gameObject.GetComponent<ToolDurability>().uses;
                bulletClone.GetComponent<ToolDurabilityDrop>().enchants = weapons[firstWeapon].gameObject.GetComponent<EnchantTool>().enchants;
            }
        }
        else if(whichWeaponHolding == false)
            if (secondWeapon != 0)
            {
                swapWeapon(0);
                whichWeaponHolding = true;
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[secondWeapon].SetActive(true);

                Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

                GameObject bulletClone = Instantiate(weapon);
                bulletClone.transform.position = shootSpot.transform.position;
                Vector3 armPos = new Vector3(0, 0, shootSpot.transform.rotation.z);
                bulletClone.transform.rotation = Quaternion.Euler(armPos);

                bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.up * speed;

                bulletClone.GetComponent<ToolDurabilityDrop>().uses = weapons[secondWeapon].gameObject.GetComponent<ToolDurability>().uses;
                bulletClone.GetComponent<ToolDurabilityDrop>().enchants = weapons[secondWeapon].gameObject.GetComponent<EnchantTool>().enchants;
            }
    }


    public void UpdateText(string text)
    {
        durability.text = text;
    }

    public void collectWeapon(int weaponNumber, GameObject collision)
    {
        if(characterSkinController.name == "Marskman") //ranged only
        {
            if (weapons[weaponNumber].GetComponent<EnchantTool>().ranged)
            {
                if (firstWeapon == 0)
                {
                    if (weaponNumber != secondWeapon)
                    {
                        weapons[weaponNumber].SetActive(true);
                        weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                        weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;

                        whichWeaponHolding = true;
                        firstWeapon = weaponNumber;
                        durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                        weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                        swapWeapon(0);
                    }

                }
                else if (secondWeapon == 0)
                {
                    if (weaponNumber != firstWeapon)
                    {
                        weapons[weaponNumber].SetActive(true);
                        weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                        weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;
                        whichWeaponHolding = false;
                        secondWeapon = weaponNumber;
                        durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                        weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                        swapWeapon(1);
                    }

                }
            }
        } //only for ranged
        else if (characterSkinController.name == "text") //only for melee
        {
            if (weapons[weaponNumber].GetComponent<EnchantTool>().melee)
            {
                if (firstWeapon == 0)
                {
                    if (weaponNumber != secondWeapon)
                    {
                        weapons[weaponNumber].SetActive(true);
                        weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                        weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;

                        whichWeaponHolding = true;
                        firstWeapon = weaponNumber;
                        durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                        weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                        swapWeapon(0);
                    }

                }
                else if (secondWeapon == 0)
                {
                    if (weaponNumber != firstWeapon)
                    {
                        weapons[weaponNumber].SetActive(true);
                        weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                        weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;
                        whichWeaponHolding = false;
                        secondWeapon = weaponNumber;
                        durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                        weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                        swapWeapon(1);
                    }

                }
            }
        } //only for melee
        else
        {
            if (firstWeapon == 0)
            {
                if (weaponNumber != secondWeapon)
                {
                    weapons[weaponNumber].SetActive(true);
                    weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                    weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;

                    whichWeaponHolding = true;
                    firstWeapon = weaponNumber;
                    durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                    weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                    swapWeapon(0);
                }

            }
            else if (secondWeapon == 0)
            {
                if (weaponNumber != firstWeapon)
                {
                    weapons[weaponNumber].SetActive(true);
                    weapons[weaponNumber].GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
                    weapons[weaponNumber].gameObject.GetComponent<EnchantTool>().enchants = collision.GetComponent<ToolDurabilityDrop>().enchants;
                    whichWeaponHolding = false;
                    secondWeapon = weaponNumber;
                    durability.text = "Durability: " + weapons[weaponNumber].GetComponent<ToolDurability>().uses;
                    weapons[weaponNumber].GetComponent<ToolDurability>().maxUses = collision.GetComponent<ToolDurabilityDrop>().maxUses;
                    swapWeapon(1);
                }

            }
        } //skins don't matter
        


    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class InventoryManager : MonoBehaviour
//{
//    public GameObject sword;
//    public GameObject pistol;
//    public GameObject Ak;

//    public GameObject swordClone;
//    public GameObject pistolClone;
//    public GameObject akClone;

//    public bool holding = false;
//    public int isHolding = 0;

//    public Camera cam;
//    public GameObject shootSpot;
//    public float speed = 50f;
//    public TextMeshPro durability;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!holding)
//        {
//            durability.text = "";
//        }
//        if(Input.GetKeyDown(KeyCode.Q))
//        {
//            holding = false;
//            if (isHolding == 1)
//            {
//                Throw(swordClone);
//            }
//            if (isHolding == 2)
//            {
//                Throw(pistolClone);
//            }
//            if (isHolding == 3)
//            {
//                Throw(akClone);
//            }
//            isHolding = 0;
//            sword.SetActive(false);
//            pistol.SetActive(false);
//            Ak.SetActive(false);


//        }
//    }

//    public void Throw(GameObject weapon)
//    {
//        Vector2 mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

//        GameObject bulletClone = Instantiate(weapon);
//        bulletClone.transform.position = shootSpot.transform.position;
//        Vector3 armPos = new Vector3(0, 0, shootSpot.transform.rotation.z);
//        bulletClone.transform.rotation = Quaternion.Euler(armPos);

//        bulletClone.GetComponent<Rigidbody2D>().velocity = -shootSpot.transform.up * speed;

//        if(isHolding == 1)
//        {
//            bulletClone.GetComponent<ToolDurabilityDrop>().uses = sword.GetComponent<ToolDurability>().uses;
//        }
//        if (isHolding == 2)
//        {
//            bulletClone.GetComponent<ToolDurabilityDrop>().uses = pistol.GetComponent<ToolDurability>().uses;
//        }
//        if (isHolding == 3)
//        {
//            bulletClone.GetComponent<ToolDurabilityDrop>().uses = Ak.GetComponent<ToolDurability>().uses;
//        }


//    }


//    public void UpdateText()
//    {
//        durability.text = "Durability fixed!";
//    }

//    public void collectWeapon(int weaponNumber, GameObject collision)
//    {
//        holding = true;

//        if (weaponNumber == 0)
//        {
//            sword.SetActive(true);
//            sword.GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
//            isHolding = 1;
//            durability.text = "Durability: " + sword.GetComponent<ToolDurability>().uses;
//        }
//        if (weaponNumber == 1)
//        {
//            pistol.SetActive(true);
//            isHolding = 2;
//            pistol.GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
//            durability.text = "Durability: " + pistol.GetComponent<ToolDurability>().uses;

//        }
//        if (weaponNumber == 2)
//        {
//            Ak.SetActive(true);
//            isHolding = 3;
//            Ak.GetComponent<ToolDurability>().uses = collision.GetComponent<ToolDurabilityDrop>().uses;
//            durability.text = "Durability: " + Ak.GetComponent<ToolDurability>().uses;

//        }

//    }
//}



