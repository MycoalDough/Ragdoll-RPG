using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public inGameCurrency controller;
    public GameObject child;
    public CurrencyManager player;

    public TextMeshProUGUI coin;
    public TextMeshProUGUI kills;
    public TextMeshProUGUI time;
    public TextMeshProUGUI levels;

    public TextMeshProUGUI final;


    public int coinVal;
    public int killsVal;
    public int timeVal;
    public int levelsVal;

    public int finalVal;
    // Start is called before the first frame update
    void Start()
    {
        coinVal = 0;
        killsVal = 0;
        timeVal = 0;
        levelsVal = 0;
        finalVal = 0;
        child.SetActive(false);
        controller = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!controller)
        {
            controller = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
        }
    }

    public void Finish()
    {
        child.SetActive(true);
        Time.timeScale = 0f;

        coinVal = Mathf.RoundToInt(controller.coins / 12);
        killsVal = Mathf.RoundToInt(controller.enemyKills / 5);
        levelsVal = controller.levelsPassed * 5;
        timeVal = Mathf.RoundToInt(controller.elaspedTime / 100);

        finalVal = coinVal + killsVal + levelsVal + timeVal;
        player.tokens = finalVal + player.tokens;

        coin.text = "" + coinVal;
        kills.text = "" + killsVal;
        levels.text = "" + levelsVal;
        time.text = "" + timeVal;

        final.text = "" + finalVal;


    }
}
