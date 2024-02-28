using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    [Header("Classes")]
    public int tokens;
    public bool marksman;
    public bool berserker;
    public bool ninja;
    public bool giant;
    public bool hacker;
    public bool necromancer;
    public bool engineer;
    public bool medic;
    public bool golem;
    public bool kog; //king of gold
    public bool boxer;
    public bool knight;
    public bool enchanter;
    public bool alchemist;
    public bool bounty; //bounty hunter
    public bool wizard;
    public bool angel;
    public bool gardener;
    public bool archer;
    public bool sheild;

    public TextMeshProUGUI[] texts;

    //public TextMeshProUGUI text;
    //public bool useText;

    private void Start()
    {
        //commons: 6
        //rares: 4
        //epics: 5
        //legendaries: 3
        //mythicals: 2


        PlayerData data = SaveSystem.LoadPlayer(this);
        marksman = data.marksman; //rare
        berserker = data.berserker; //epic
        ninja = data.ninja; //rare
        giant = data.giant; //legendary
        hacker = data.hacker; //legendary
        necromancer = data.necromancer; //epic
        engineer = data.engineer; //rare
        medic = data.medic; //common
        golem = data.golem; //epic
        kog = data.kog; //rare
        boxer = data.boxer; //common
        knight = data.knight; //common
        enchanter = data.enchanter; //legendary
        alchemist = data.alchemist; //mythical
        bounty = data.bounty; //epic
        wizard = data.wizard; //common
        angel = data.knight; //mythical
        gardener = data.enchanter; //common
        archer = data.alchemist; //common
        sheild = data.bounty; //epic

        tokens = data.tokens;
    }


    private void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }

    private void OnDestroy()
    {
        SaveSystem.SavePlayer(this);

    }

    private void Update()
    {
        SaveSystem.SavePlayer(this);

        if(texts.Length > 0)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].text = "Tokens: " + tokens;
            }
        }

    }
}
