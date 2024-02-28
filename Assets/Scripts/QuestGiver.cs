using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public GameObject questWindow;
    public GameObject acceptButton;

    public GameObject screen;
    public bool isOpen = false;


    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI tokenRewardText;
    public TextMeshProUGUI progress;


    public bool canCount = false;
    public int randomQuest;

    public void openQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.questArray[randomQuest].title;
        descriptionText.text = quest.questArray[randomQuest].description;
        tokenRewardText.text = quest.questArray[randomQuest].tokenReward.ToString();
        string type = quest.questArray[randomQuest].goalTypeArray.ToString();
        quest.goal.goalType = (GoalType)System.Enum.Parse(typeof(GoalType), type);
        quest.goal.requiredAmount = quest.questArray[randomQuest].reqAmount;
        quest.goal.currentAmount = 0;
    }
    public void openQuests()
    {
        openQuestWindow();
        if (isOpen)
        {
            isOpen = false;
            screen.SetActive(false);
        }
        else if (!isOpen)
        {
            isOpen = true;
            screen.SetActive(true);
        }
    }
    public void acceptQuest()
    {
        if(!quest.isActive)
        {
            progress.gameObject.SetActive(true);
            acceptButton.gameObject.SetActive(false);
            quest.isActive = true;
            canCount = true;
            quest.isActive = true;
        }
        //give the portal, enemy, and collectables able to do quests, portal - pass levels, enemies - kill / dmg, collectables - collect, and so on
    }

    public void Update()
    {
        if(canCount)
        {
            progress.text = "" + quest.goal.currentAmount + " / " + quest.goal.requiredAmount;
        }
        if (!quest.newQuest)
        {
            quest.newQuest = true;
            randomQuest = Random.Range(0, quest.questArray.Length);

            titleText.text = quest.questArray[randomQuest].title;
            descriptionText.text = quest.questArray[randomQuest].description;
            tokenRewardText.text = quest.questArray[randomQuest].tokenReward.ToString();
            acceptButton.SetActive(true);
        }
    }
}
