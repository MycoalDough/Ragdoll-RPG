using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestArray
{
    public string title;
    public string description;
    public int tokenReward;
    public GoalType goalTypeArray;
    public int reqAmount;

    public enum GoalType
    {
        KillEnemies,
        KillBosses,
        KillMelee,
        GatherGold,
        GatherWeapons,
        PassLevels,
        DamageEnemies
        //kill with types of weapons?
        //add hardness types, such as killenemies1: 20 enemies, killenemies2: 40 eneimes
    }
}
