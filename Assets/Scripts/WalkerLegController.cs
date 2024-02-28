using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerLegController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
        }
    }

    public void destroyJoint()
    {
        Destroy(gameObject.GetComponent<FixedJoint2D>());
    }
}
