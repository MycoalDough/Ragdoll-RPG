using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltrakillSkin : MonoBehaviour
{
    private CharacterSkinController csc;

    public inGameCurrency igc;

    public Transform body;
    public GameObject coin;

    public void Start()
    {
        csc = GetComponent<CharacterSkinController>();
        if(csc.skin != "Ultrakill")
        {
            GetComponent<UltrakillSkin>().enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(igc.coins - 1 >= 0)
            {
                igc.addCoins(-1);

                Instantiate(coin, body.position, Quaternion.identity);

            }
        }
    }
}
