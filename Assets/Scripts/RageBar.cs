using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public float rage;
    public bool canRage;
    public float maxRage = 100f;

    public Image rageBar;

    public CharacterSkinController csc;
    public PlayerHealth ph;
    public Player player;

    public GameObject rageBarParent;

    public float newSpeed;

    public void IncreaseRage(int damage)
    {
        //Debug.Log(rage);
        if (!canRage)
        {
            rage = rage + damage * 3 / 5;
            int fillAmount = damage / 100;
            
            //increase a fill sprite bar
        }

    }

    public void Start()
    {
        newSpeed = player.movementSpeed * 1.7f;
        if (csc.skin != "Berserker")
        {
            rageBar.gameObject.SetActive(false);
            gameObject.GetComponent<RageBar>().enabled = false;
            rageBarParent.SetActive(false);

        }
    }

    public void Update()
    {
        rageBar.fillAmount = rage / 100;

        if(rage > 100)
        {
            rage = 100;
        }

        if (rage >= maxRage)
        {
            canRage = true;
        }
        else
        {
            canRage = false;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(canRage)
            {
                AcitvateRage();
            }
        }
    }


    public void AcitvateRage()
    {
        if (canRage)
        {
            canRage = false;
            StartCoroutine(raging());

        }
    }


    IEnumerator raging()
    {
        float savedForce;
        savedForce = player.movementSpeed;

        player.movementSpeed = newSpeed;
        StartCoroutine(heal());
        yield return new WaitForSeconds(20);
        player.movementSpeed = savedForce;

    }

    IEnumerator heal()
    {
        Debug.Log("heal called");

        for (int i = 0; i < 20; i++)
        {
            Debug.Log("healing loop");
            yield return new WaitForSeconds(1);

            ph.Heal(5);
            //rageBar.fillAmount = rageBar.fillAmount - 0.05f;
            Debug.Log(rage);
            rage = rage - 5f;
            //change rage bar fill by -0.05
        }
    }
}
