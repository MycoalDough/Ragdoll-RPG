using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellinTurretShoot : MonoBehaviour
{
    public Rigidbody2D RB;
    public float force = 6000;
    public GameObject player;
    public bool rightArm;
    public Transform body;

    public FindClosestTarget fct;

    public bool ispropell = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (ispropell)
        {
            player = transform.parent.GetComponent<PropellingTurretController>().target;
        }
        else
        {
            player = fct.target;

        }

        if (player != null)
        {
            Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 difference = playerpos - transform.position;
            float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
            RB.MoveRotation(Mathf.LerpAngle(RB.rotation, rotationZ, force * Time.fixedDeltaTime));
        }
    }
}
