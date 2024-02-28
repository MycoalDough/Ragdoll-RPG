using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellingTurretController : MonoBehaviour
{
    public GameObject target;
    public float distance;
    public bool inRange;
    public float distanceToClosestPlayer;
    public string targTag;

    public int weaponNumber = 21;

    public InventoryManager inv;

    public GameObject[] turretParts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findClosestTarget();

        if(inv.firstWeapon == weaponNumber)
        {
            if(inv.whichWeaponHolding)
            {
                for (int i = 0; i < turretParts.Length; i++)
                {
                    turretParts[i].SetActive(false);
                }
            }
            else if(!inv.whichWeaponHolding)
            {
                for (int i = 0; i < turretParts.Length; i++)
                {
                    turretParts[i].SetActive(true);
                }
            }
        }
        if (inv.secondWeapon == weaponNumber)
        {
            if (!inv.whichWeaponHolding)
            {
                for (int i = 0; i < turretParts.Length; i++)
                {
                    turretParts[i].SetActive(false);
                }
            }
            else if (inv.whichWeaponHolding)
            {
                for (int i = 0; i < turretParts.Length; i++)
                {
                    turretParts[i].SetActive(true);
                }
            }
        }
    }

    void findClosestTarget()
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
