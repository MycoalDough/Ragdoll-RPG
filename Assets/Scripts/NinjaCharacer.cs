using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCharacer : MonoBehaviour
{
    public CharacterSkinController csc;

    public float maxTime, time;

    public bool slowingDownTime;
    public PauseMenu pm;

    public GameObject[] clothes;

    public void Start()
    {
        slowingDownTime = false;
        csc = gameObject.GetComponent<CharacterSkinController>();

        if(csc.skin != "Ninja")
        {
            enabled = false;


        }
        else
        {
            for (int i = 0; i < clothes.Length; i++)
            {
                clothes[i].SetActive(true);
            }
        }
    }

    public void Update()
    {
        time = time + Time.deltaTime;

        if(time > maxTime)
        {
            if(Input.GetKeyDown(KeyCode.Z) && pm.isPaused == false)
            {
                StartCoroutine(slowTime());
                time = 0;
                slowingDownTime = true;

            }
        }
    }

    public IEnumerator slowTime()
    {
        slowingDownTime = true;
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(10);
        Time.timeScale = 1f;
        slowingDownTime = false;
    }
}
