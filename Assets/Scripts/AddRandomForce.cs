using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForce : MonoBehaviour
{

    public float force = 1000;
    private Vector2 rotation;
    // Start is called before the first frame update
    void Awake()
    {
        rotation = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-30,30), Random.Range(55, 120)) * force);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }

}
