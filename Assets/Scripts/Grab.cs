using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Rigidbody2D hand;
    private bool canGrab;
    private FixedJoint2D joint;
    public int isLeftOrRight;
    public GameObject currentlyHolding;
    public Camera cam;

    public float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(isLeftOrRight))
        {
            canGrab = true;

        }
        if (Input.GetMouseButtonUp(isLeftOrRight))
        {
            canGrab = false;
        }
        if(!canGrab && currentlyHolding != null)
        {
            FixedJoint2D[] joints = currentlyHolding.GetComponents<FixedJoint2D>();
            for(int i = 0; i < joints.Length; i++)
            {
                if(joints[i].connectedBody == hand)
                {
                    currentlyHolding = null;
                    Destroy(joints[i]);
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canGrab && collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            currentlyHolding = collision.gameObject;
            joint = currentlyHolding.AddComponent<FixedJoint2D>();
            joint.connectedBody = hand;
        }
    }
}
