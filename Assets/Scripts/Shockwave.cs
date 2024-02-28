using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public bool left;

    public Rigidbody2D RB;
    public float touchForce;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, -3.35f);
        //gameObject.GetComponent<Transform>().localScale = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Transform>().localScale = new Vector2(gameObject.GetComponent<Transform>().localScale.x + 0.001f, gameObject.GetComponent<Transform>().localScale.y + 0.001f);
        if (left)
        {
            RB.AddForce(Vector2.left * touchForce);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            RB.AddForce(Vector2.right * touchForce);
        }
    }
}
