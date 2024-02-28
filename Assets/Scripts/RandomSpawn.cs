using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomSpawn : MonoBehaviour
{

    public float time; //becomes random every spawn
    public int maxTime;//becomes random every spawn

    public int min, max; //the random ranges of times

    public GameObject[] random;
    public Transform sp;

    [Header("Difficulty")]
    public clickToSummon check;
    public GameObject increase;
    public TextMeshProUGUI text;
    public float diffTime = 60;
    public float diffTimeDelta = 0;
    public int diffMeter = 1;

    public bool useDiff = true;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Difficulty: " + diffMeter;
        time = 0;
        diffTimeDelta = 0;
        maxTime = Random.Range(min, max + 1);
    }

    // Update is called once per frame
    void Update()
    {

        diffTimeDelta = diffTimeDelta + Time.deltaTime;
        time = time + Time.deltaTime;

        if (time > maxTime)
        {
            
            int randomSpawn = Random.Range(0, random.Length);

            GameObject clone = Instantiate(random[randomSpawn], sp.position, Quaternion.identity);
            clone.GetComponent<EnemyController>().isInRage = true;
            maxTime = Random.Range(min, max + 1);
            time = 0;
        }

        if (useDiff)
        {
            diffTimeDelta = diffTimeDelta + Time.deltaTime;
            if (diffTimeDelta > diffTime)
            {
                diffMeter++;
                text.text = "Difficulty: " + diffMeter;
                diffTime = diffTime + 100;
                diffTimeDelta = 0;
                GameObject diff = Instantiate(increase, gameObject.transform.position, Quaternion.identity);
                diff.GetComponent<RandomSpawn>().useDiff = false;
            }

        }

    }
}
