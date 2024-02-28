using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
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


    public PlayerData(CurrencyManager player)
    {
        marksman = player.marksman;
        berserker = player.berserker;
        ninja = player.ninja;
        giant = player.giant;
        hacker = player.hacker;
        necromancer = player.necromancer;
        engineer = player.engineer;
        medic = player.medic;
        golem = player.golem;
        kog = player.kog;
        boxer = player.boxer;
        knight = player.knight;
        enchanter = player.enchanter;
        alchemist = player.alchemist;
        bounty = player.bounty;
        wizard = player.wizard; //common
        angel = player.knight; //mythical
        gardener = player.enchanter; //common
        archer = player.alchemist; //common
        sheild = player.bounty; //epic

        tokens = player.tokens;

    }

}
