using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 lastVelocity;

    public int bouncesLeft;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

        if(bouncesLeft == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = dir * Mathf.Max(speed, 0f);
        bouncesLeft = bouncesLeft - 1;
    }
}
