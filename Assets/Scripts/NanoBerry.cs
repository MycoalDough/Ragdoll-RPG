using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBerry : MonoBehaviour
{
    public float time;
    public float timeTilReady;
    public bool canEat;
    public PlayerHealth plrHP;

    public GameObject berry;
    public GameObject nanoberry;




    void Update()
    {
        if(nanoberry.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && canEat)
            {
                canEat = false;
                time = 0f;
                plrHP.Heal(30);
                berry.SetActive(false);
            }
        }
        if (time < timeTilReady)
        {
            time = time + Time.deltaTime;
            canEat = false;
        }
        else if (time > timeTilReady)
        {
            canEat = true;
            berry.SetActive(true);
        }


    }
}
