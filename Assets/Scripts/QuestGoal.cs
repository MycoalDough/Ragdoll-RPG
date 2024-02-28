using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.KillEnemies)
        {
            currentAmount++;
        }
    }
    public void DamageDone(int dmg)
    {
        if (goalType == GoalType.DamageEnemies)
        {
            currentAmount = currentAmount + dmg;
        }
    }
}

public enum GoalType
{
    KillEnemies,
    KillBosses,
    GatherApples,
    GatherGold,
    GatherWeapons,
    PassLevels,
    DamageEnemies
        //kill with types of weapons?
        //add hardness types, such as killenemies1: 20 enemies, killenemies2: 40 eneimes
}
