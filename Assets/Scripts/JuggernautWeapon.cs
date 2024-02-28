using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautWeapon : MonoBehaviour
{
    public float time, MaxTime;

    public GameObject shockwave;
    public Transform shockwaveSpawn;

    public Animator anim;


    private void Update()
    {
        time = time + Time.deltaTime;
        if(time > MaxTime)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                time = 0;
                GameObject shockwaveSummon = Instantiate(shockwave, shockwaveSpawn.position, Quaternion.identity);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    shockwaveSummon.GetComponent<Shockwave>().left = true;
                }
                else
                {
                    shockwaveSummon.GetComponent<Shockwave>().left = false;
                }
            }
        }
    }
}
