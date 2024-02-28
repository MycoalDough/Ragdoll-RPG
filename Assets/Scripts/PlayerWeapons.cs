using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{

    public GameObject[] items;

    public bool[] enchants;
    // Start is called before the first frame update
    void Start()
    {
        enchants = new bool[10];
    }

    // Update is called once per frame
    void GenerateRandomNumber(int setRandomMin, int setRandomMax)
    {
        int random = Random.Range(setRandomMin, setRandomMax + 1);
    }
}
