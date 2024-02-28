using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageSpawn : MonoBehaviour
{

    public GameObject[] trees;
    public float maxRange, minRange;
    public int maxTrees, minTrees;

    public bool useRandomValues = true;
    // Start is called before the first frame update
    public void Start()
    {
        int TreeAmount = Random.Range(minTrees, maxTrees + 1);

        for (int i = 0; i < TreeAmount; i++)
        {

            //look different
            int flipped = Random.Range(0, 2);


            float spawnX = Random.Range(minRange, maxRange);
            Vector2 randomSpawnPoint = new Vector2(spawnX, -0.5f);
            int treeToSpawn = Random.Range(0, trees.Length);

            GameObject newTree = Instantiate(trees[treeToSpawn], randomSpawnPoint, Quaternion.identity);
            if (flipped == 1 && newTree.GetComponent<SpriteRenderer>())
            {
                newTree.GetComponent<SpriteRenderer>().flipX = true;
            }

            if(newTree.GetComponent<SpriteRenderer>())
            {
                newTree.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-5, 0);
            }

            if (useRandomValues)
            {
                float sizeX = Random.Range(0.8f, 1.3f);
                float sizeY = Random.Range(0.9f, 1.3f);
                newTree.GetComponent<Transform>().localScale = new Vector3(sizeX, sizeY, 1);
            }
        }
    }
}
