using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    public float destoryTime;

    public bool isLeft;
    public bool isLaser = true;
    public bool isSpore = false;

    // Start is called before the first frame update
    void Awake()
    {

        StartCoroutine(destroy());
        if (isLaser)
        {
            if (GameObject.FindObjectOfType<Animator>() != null)
            {
                Animator animator = GameObject.FindObjectOfType<Animator>().GetComponent<Animator>();
                if (isLeft)
                {
                    animator.Play("ShootLaserLeft");
                }
                else
                {
                    animator.Play("ShootLaserRIght");
                }
            }
        }

        if(isSpore)
        {
            spore();
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destoryTime);
        Destroy(gameObject);
    }

    void spore()
    {
        StartCoroutine(sporeCd());
    }

    IEnumerator sporeCd()
    {
        gameObject.tag = "Melee";
        yield return new WaitForSeconds(1.25f);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1.25f);
        spore();
    }

}
