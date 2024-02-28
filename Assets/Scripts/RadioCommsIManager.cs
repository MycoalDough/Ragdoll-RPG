using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioCommsIManager : MonoBehaviour
{
    public Animator anim;
    public Transform player;

    public GameObject crate;

    public Image fill;

    public int current;
    public int needed = 1700;

    void Update()
    {
        fill.fillAmount = (float)current / (float)needed;
        if (current >= needed)
        {
            current = 0;
            anim.Play("RadioCommsIAnim");
            Instantiate(crate, new Vector2(player.transform.position.x, 100), Quaternion.identity);
        }
    }
}
