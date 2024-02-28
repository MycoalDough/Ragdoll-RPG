using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class inGameCurrency : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI text;
    public float elaspedTime = 0f;
    public float timePlaying = 0f;
    public int levelsPassed = -1;

    public UpgradeManager um;

    public int tickets;

    public bool debounce;

    public int enemyKills = 0;
    private void OnLevelWasLoaded(int level)
    {
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();

        text = GameObject.Find("coinAmount").gameObject.GetComponent<TextMeshProUGUI>();
        addCoins(0);

        if(um.bankAccount)
        {
            coins = (int)(coins * 1.25f);
        }

        if (SceneManager.GetActiveScene().name != "TheGate")
        {
            if (SceneManager.GetActiveScene().name != "Lobby")
            {
                levelsPassed++;
            }
        }

    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            elaspedTime += Time.deltaTime;
            timePlaying = elaspedTime;
        }
    }

    private void OnApplicationQuit()
    {
        elaspedTime = timePlaying;
    }

    public void addCoins(int moneyToAdd)
    {
        if(!debounce)
        {
            coins = coins + moneyToAdd;
            text.text = "Coins: " + coins;
            debounce = true;
            StartCoroutine(db());
        }
    }

    public void GainKill(int number)
    {
        enemyKills = enemyKills + number;
    }

    IEnumerator db()
    {
        yield return new WaitForSeconds(0.01f);
        debounce = false;
    }
}
