using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantForce : MonoBehaviour
{

    public float force;

    public float timeToWait;
    public float time;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        time = time + Time.fixedDeltaTime;

        if(time > timeToWait)
        {
            time = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-90, 90), 0) * force);
        }
    }
}
