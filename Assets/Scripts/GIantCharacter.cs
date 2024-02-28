using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIantCharacter : MonoBehaviour
{
    public CharacterSkinController csc;
    public float xVal;
    public float yVal;

    public Player pl;
    public PlayerHealth ph;
    public float maxTime, time;
    public bool canUse;

    public GameObject[] allLimbs;

    private void Start()
    {
        if(csc.skin == "Giant")
        {
            ph.maxHealth = 150;
            ph.currentHealth = 150;
            pl.movementSpeed = 350;
            pl.raycastDistance = 2.05f;
        }

    }
    void Awake()
    {
        if (csc.skin == "Giant")
        {
            for (int i = 0; i < allLimbs.Length; i++)
            {
                allLimbs[i].transform.localScale = new Vector2(allLimbs[i].transform.localScale.x * xVal * xVal, allLimbs[i].transform.localScale.y * yVal * yVal);
            }
        }
        else
        {
            gameObject.GetComponent<GIantCharacter>().enabled = false;
        }


    }

    private void Update()
    {
        enbiggen();
    }
    void enbiggen()
    {
        time = time + Time.deltaTime;

        if(time > maxTime)
        {
            canUse = true;

            if(Input.GetKeyDown(KeyCode.Z))
            {
                time = 0;
                canUse = false;
                StartCoroutine(enlarge());
            }
        }
    }

    IEnumerator enlarge()
    {
        pl.raycastDistance = 2.7f;

        for (int i = 0; i < allLimbs.Length; i++)
        {
            allLimbs[i].transform.localScale = new Vector2(allLimbs[i].transform.localScale.x * xVal * xVal, allLimbs[i].transform.localScale.y * yVal * yVal);
        }
        yield return new WaitForSeconds(10);
        for (int i = 0; i < allLimbs.Length; i++)
        {
            allLimbs[i].transform.localScale = new Vector2(allLimbs[i].transform.localScale.x / xVal / xVal, allLimbs[i].transform.localScale.y / yVal / yVal);
        }
        pl.raycastDistance = 2.05f;

    }
}
