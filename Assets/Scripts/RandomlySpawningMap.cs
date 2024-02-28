using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySpawningMap : MonoBehaviour
{
    public GameObject[] chunks;

    public GameObject portal;
    public int chunksToSpawn;
    public Vector2 spawnPoints;

    public int chunk;
    public FoliageSpawn foliageSpawn;

    
    // Start is called before the first frame update
    void Start()
    {
        foliageSpawn = gameObject.GetComponent<FoliageSpawn>();

        for (int i = 0; i < chunksToSpawn; i++)
        {
            int spawnChunk = Random.Range(0, 5);
            if (spawnChunk != 0)
            {
                chunk = Random.Range(0, chunks.Length);
                spawnPoints = new Vector2(spawnPoints.x + chunks[chunk].gameObject.GetComponent<Transform>().localScale.x, spawnPoints.y);

                GameObject newTree = Instantiate(chunks[chunk], spawnPoints, Quaternion.identity);
            }
            else
            {

                    spawnPoints = new Vector2(spawnPoints.x + chunks[11].gameObject.GetComponent<Transform>().localScale.x, spawnPoints.y);

                    GameObject newTree = Instantiate(chunks[11], spawnPoints, Quaternion.identity);

            }
        }
        Instantiate(portal, new Vector2(spawnPoints.x + chunks[chunk].gameObject.GetComponent<Transform>().localScale.x, spawnPoints.y), Quaternion.identity);
        //foliageSpawn.SpawnTrees();
    }
}
