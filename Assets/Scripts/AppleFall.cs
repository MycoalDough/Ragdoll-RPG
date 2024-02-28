using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9 || collision.gameObject.layer == 14 || collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject.GetComponent<FixedJoint2D>());
        }
    }
}
