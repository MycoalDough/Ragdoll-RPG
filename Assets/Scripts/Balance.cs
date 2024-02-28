using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{

    public float rotation = 0f;
    public float force = 750f;

    public bool isRagdolled = false;
    public float savedForce;

    private Rigidbody2D rb;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        savedForce = force;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotation, force * Time.deltaTime));
        }
    }
}
