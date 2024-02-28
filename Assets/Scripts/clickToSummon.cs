using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToSummon : MonoBehaviour
{

    public int enemies = 0;
    public int maxEnemies = 60;

    public inGameCurrency currency;
    public bool inRange = false;
    public Transform spawnPoint;

    public GameObject[] summons;


    // Start is called before the first frame update
    void Start()
    {
        currency = GameObject.FindObjectOfType<inGameCurrency>().GetComponent<inGameCurrency>();
    }

    // Update is called once per frame
    public void Buy(string costUnit)
    {
        string[] split = costUnit.Split(char.Parse(","));
        int cost = int.Parse(split[0]);
        int summonVar = int.Parse(split[1]);

        if (currency.coins >= cost)
        {
            currency.addCoins(-cost);
            Instantiate(summons[summonVar], spawnPoint.position, Quaternion.identity);
        }
    }
}
