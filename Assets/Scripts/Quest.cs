using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool isActive;

    public QuestArray[] questArray;

    public QuestGoal goal;
    public bool newQuest;

    public void Complete()
    {
        isActive = false;
        newQuest = false;
        Debug.Log("A quest was completed!");
    }
}
