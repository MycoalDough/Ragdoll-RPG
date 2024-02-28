using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float force = 6000;
    public GameObject player;
    public bool rightArm;
    public Transform body;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent.GetComponent<EnemyController>())
        {
            player = transform.parent.GetComponent<EnemyController>().target;
        }




        if (player != null)
        {
            if (!rightArm)
            {
                Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 difference = playerpos - transform.position;
                float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
                RB.MoveRotation(Mathf.LerpAngle(RB.rotation, rotationZ, force * Time.fixedDeltaTime));
            }
            if (rightArm && transform.parent.GetComponent<EnemyController>().onRight == false)
            {
                Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 difference = playerpos - transform.position;
                float rotationZ = Mathf.Atan2(-difference.x, -difference.y) * Mathf.Rad2Deg;
                RB.MoveRotation(Mathf.LerpAngle(RB.rotation, rotationZ, force * Time.fixedDeltaTime));
            }
        }

    }
}
