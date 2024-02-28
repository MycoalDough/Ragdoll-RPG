using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonOnPos : MonoBehaviour
{
    public GameObject spawnPos;
    public float time;
    public int maxTime;

    public GameObject[] spawnable;

    public int min, max;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = Random.Range(min, max + 1);

    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if(time > maxTime)
        {
            Instantiate(spawnable[Random.Range(0, spawnable.Length)], new Vector2(spawnPos.transform.position.x, spawnPos.transform.position.y + 5), Quaternion.identity);
            time = 0;
            maxTime = Random.Range(min, max + 1);
        }
    }
}
