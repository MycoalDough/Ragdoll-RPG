using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [Header("Movement & AI")]
    public float distance;
    public GameObject hips;
    public bool onRight;
    public Animator anim;
    public Rigidbody2D RB;
    public float touchForce = 6;

    public int minX, maxX;

    public float time = 0;
    public float maxTime = 10;

    public float min = 3, max = 10;

    public GameObject locationToMove;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = Random.Range(min, max + 1);
        locationToMove.transform.position = new Vector2(Random.Range(minX, maxX), locationToMove.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;

        if(time > maxTime)
        {
            time = 0;
            locationToMove.transform.position = new Vector2(Random.Range(minX, maxX), locationToMove.transform.position.y);
            maxTime = Random.Range(min, max + 1);
        }
        distance = Vector2.Distance(locationToMove.transform.position, hips.transform.position);
        if (locationToMove.transform.position.x < hips.transform.position.x)
        {
            onRight = true;
        }
        else { onRight = false; }

        if (distance > 1)
        {
            if (onRight)
            {
                anim.Play("Walk Back");
                RB.AddForce(Vector2.left * touchForce);
            }
            else
            {
                anim.Play("Walk");
                RB.AddForce(Vector2.right * touchForce);
            }
        }
        else { anim.Play("Idle"); };

    }


}




