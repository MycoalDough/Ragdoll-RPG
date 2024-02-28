using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaPlayerItem : MonoBehaviour
{
    public Player player;
    public GameObject spriteOpen;
    public GameObject spriteClose;

    void Start()
    {
    }

    void Update()
    {
        if (player.isGrounded())
        {
            spriteClose.SetActive(true);
            spriteOpen.SetActive(false);

        }
        else if (!player.isGrounded())
        {

            spriteClose.SetActive(false);
            spriteOpen.SetActive(true);
        }
    }
}
