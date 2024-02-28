using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Albowtross_Flight : MonoBehaviour
{

    public float flightForce;
    public float yPos;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yPos)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * flightForce * Time.deltaTime);
        }
    }
}
