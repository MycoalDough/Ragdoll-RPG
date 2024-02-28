using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RandomMutation : MonoBehaviour
{
    public Sprite[] icons;
    public string[] mutationName;
    public string[] info;

    public GameObject icon;
    public TextMeshProUGUI mutName;
    public TextMeshProUGUI desc;

    public MutationSkin ms;


    int random;

    private void OnEnable()
    {
        randomMutation();

    }

    public void randomMutation()
    {
        random = Random.Range(0, icons.Length);

        ms = GameObject.FindObjectOfType<MutationSkin>().GetComponent<MutationSkin>();

        mutName.text = mutationName[random];
        desc.text = info[random];
        CustomButton.onClick.AddListener(CustomButton_onClick);
    }
    public Button CustomButton; //drag-n-drop the button in the CustomButton field

    //Handle the onClick event
    void CustomButton_onClick()
    {
        if(mutName.text == "Tough")
        {
            ms.tough();
        }
        if (mutName.text == "Speed")
        {
            ms.speed();
        }
        if (mutName.text == "Reach")
        {
            ms.reach();
        }
        if (mutName.text == "Shrink")
        {
            ms.mini();
        }
        if (mutName.text == "Enbiggen")
        {
            ms.tough();
        }
        if (mutName.text == "Damage")
        {
            ms.damage();
        }
        if (mutName.text == "Crawler")
        {
            ms.crawler();
        }
        if (mutName.text == "Jaw")
        {
            ms.jaw();
        }
        if (mutName.text == "Rocket Arms")
        {
            ms.rocketArm();
        }
        if (mutName.text == "Stealth")
        {
            ms.stealth();
        }
        if (mutName.text == "Bile")
        {
            ms.acidPool();
        }
        if (mutName.text == "Claw")
        {
            ms.claw();
        }
        if (mutName.text == "Siren")
        {
            ms.sirenActivate();
        }
        if (mutName.text == "Parasite")
        {
            ms.parasiteSpawn();
        }
        if (mutName.text == "Devil")
        {
            ms.devil();
        }
    }


}
