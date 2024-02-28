using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerCharacter : MonoBehaviour
{
    private CharacterSkinController csc;

    [SerializeField] private float spawnInTime, spawnInMaxTime;
    [SerializeField] private float foodTime, foodMaxTime;
    [SerializeField] private float rngRocket, rngRocketMax;

    public GameObject[] hackedInTeam;
    public GameObject hackedInFood;

    public GameObject error;

    public GameObject[] hackerClothes;
    public GameObject rocket;

    public Transform spawnPosition;


    public void Start()
    {
        csc = GetComponent<CharacterSkinController>();

        if(csc.skin == "Hacker")
        {
            for (int i = 0; i < hackerClothes.Length; i++)
            {
                hackerClothes[i].SetActive(true);
            }
        }
        else
        {
            enabled = false;
        }
    }

    public void Update()
    {
        spawnInTime = spawnInTime + Time.deltaTime;
        foodTime = foodTime + Time.deltaTime;
        rngRocket = rngRocket + Time.deltaTime;


        if (spawnInTime > spawnInMaxTime)
        {
            spawnInMaxTime = Random.Range(30, 51);
            spawnInTime = 0;
            GameObject t = Instantiate(hackedInTeam[Random.Range(0, hackedInTeam.Length)], new Vector3(spawnPosition.position.x, spawnPosition.position.y + 4), Quaternion.identity);
            Instantiate(error, t.transform.position, Quaternion.identity);
        }
        if (foodTime > foodMaxTime)
        {
            foodMaxTime = Random.Range(50, 60);
            foodTime = 0;
            GameObject t = Instantiate(hackedInFood, new Vector3(spawnPosition.position.x + 3, spawnPosition.position.y + 4), Quaternion.identity);
            Instantiate(error, t.transform.position, Quaternion.identity);

        }
        if (rngRocket > rngRocketMax)
        {
            GameObject t =Instantiate(rocket, spawnPosition.position, Quaternion.identity);
            Instantiate(error, t.transform.position, Quaternion.identity);
            rngRocketMax = Random.Range(5, 20);
            rngRocket = 0;
        }
    }

}
