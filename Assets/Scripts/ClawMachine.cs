using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour
{
    public GameObject canvas;

    public bool common = false;
    public bool lucky = false;
    public bool ethereal = false;

    public Animator anim;

    public GameObject commonC;
    public GameObject rareC;
    public GameObject epicC;
    public GameObject legendaryC;
    public GameObject mythicC;



    // <COMMON>
    //common has a 85% chance
    //rare has 10%
    //epic has 5%
    //legendary has none
    //mythic has none
    // <COMMON>

    // <LUCKY>
    //common has 45% chance
    //rare has 30% 
    //epic has 20% 
    //legendary has 10%
    //mythic has none
    // <LUCKY>

    // <ETHERAL>
    //common has 0% chance
    //rare has 0%
    //epic has 45%
    //legendary has 35% 
    //mythic has 20%
    // <ETHERAL>


    public void PurchasedCommon()
    {

        int chance = Random.Range(1, 101);

        canvas.SetActive(false);
        gameObject.SetActive(true);
        if (chance <= 5)
        {
            Debug.Log("epic");
            StartCoroutine(DrawEpic(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Epic");

        }
        else if(chance >= 6 && chance < 16)
        {
            Debug.Log("rare");
            StartCoroutine(DrawRare(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Rare");

        }
        else if (chance >= 16)
        {
            Debug.Log("common");
            anim.Play("ClawMachineCommon_Common");
            StartCoroutine(DrawCommon(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    public void PurchasedLucky()
    {

        int chance = Random.Range(1, 101);

        canvas.SetActive(false);
        gameObject.SetActive(true);
        if (chance <= 10)
        {
            Debug.Log("legendary");
            StartCoroutine(DrawLegendary(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Legendary");

        }
        else if (chance >= 11 && chance < 31)
        {
            Debug.Log("epic");
            StartCoroutine(DrawEpic(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Epic");

        }
        else if (chance >= 31 && chance < 51)
        {
            Debug.Log("rare");
            anim.Play("ClawMachineCommon_Rare");
            StartCoroutine(DrawRare(anim.GetCurrentAnimatorStateInfo(0).length));
        }
        else if (chance >= 100)
        {
            Debug.Log("common");
            anim.Play("ClawMachineCommon_Common");
            StartCoroutine(DrawCommon(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    public void PurchasedEthereal()
    {

        int chance = Random.Range(1, 101);

        canvas.SetActive(false);
        gameObject.SetActive(true);
        if (chance <= 20)
        {
            Debug.Log("mythic");
            StartCoroutine(DrawMythic(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Mythic");

        }
        else if (chance >= 21 && chance < 56)
        {
            Debug.Log("legendary");
            StartCoroutine(DrawLegendary(anim.GetCurrentAnimatorStateInfo(0).length));
            anim.Play("ClawMachineCommon_Legendary");

        }
        else if (chance >= 56)
        {
            Debug.Log("epic");
            anim.Play("ClawMachineCommon_Epic");
            StartCoroutine(DrawEpic(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }


    IEnumerator DrawCommon(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        yield return new WaitForSeconds(7.6f);

        //Show Dead UI..
        GameObject clone = Instantiate(commonC, commonC.transform.position, commonC.transform.rotation);
        clone.GetComponent<CapsuleOpen>().canvas = canvas;
        gameObject.SetActive(false);

    }

    IEnumerator DrawRare(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        yield return new WaitForSeconds(7.6f);
        //Show Dead UI..
        GameObject clone = Instantiate(rareC, rareC.transform.position, rareC.transform.rotation);
        clone.GetComponent<CapsuleOpen>().canvas = canvas;
        gameObject.SetActive(false);

    }

    IEnumerator DrawEpic(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        yield return new WaitForSeconds(7.6f);
        //Show Dead UI..
        GameObject clone = Instantiate(epicC, epicC.transform.position, epicC.transform.rotation);
        clone.GetComponent<CapsuleOpen>().canvas = canvas;
        gameObject.SetActive(false);

    }

    IEnumerator DrawLegendary(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        yield return new WaitForSeconds(7.6f);
        //Show Dead UI..
        GameObject clone = Instantiate(legendaryC, legendaryC.transform.position, legendaryC.transform.rotation);
        clone.GetComponent<CapsuleOpen>().canvas = canvas;
        gameObject.SetActive(false);

    }


    IEnumerator DrawMythic(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        yield return new WaitForSeconds(7.6f);
        //Show Dead UI..
        GameObject clone = Instantiate(mythicC, mythicC.transform.position, mythicC.transform.rotation);
        clone.GetComponent<CapsuleOpen>().canvas = canvas;
        gameObject.SetActive(false);

    }

}
