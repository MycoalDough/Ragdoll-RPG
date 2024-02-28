using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGun : MonoBehaviour
{
    public float landingSite;
    public GameObject flareSmoke;
    public GameObject crate;
    public int db = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(db == 0)
        {
            db = 1;
            Instantiate(flareSmoke, gameObject.transform.position, Quaternion.identity);
            landingSite = (gameObject.transform.position.x);
            spawnCrate();
            Destroy(gameObject);
        }

    }

    public void spawnCrate()
    {
        Instantiate(crate, new Vector2(landingSite, 100), Quaternion.identity);
    }
}
