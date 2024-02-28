using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddForce : MonoBehaviour
{
    public float force = 10;

    public Vector2 armVector;

    public Transform arm;

    public float cooldown = 2f;
    private float cooldownTimer = 0f;
    private bool cooldownActive = false;

    public bool isInRange = false;

    public void FixedUpdate()
    {

        armVector = new Vector2(arm.position.x, arm.position.y);

        Vector2 attackPos = (armVector - new Vector2(transform.position.x, transform.position.y));
        if(isInRange)
        {
            if(cooldownActive == false)
            {
                cooldownTimer = 0;
                cooldownActive = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = (attackPos * force);
            }
        }
        if (cooldownActive)
        {
            cooldownTimer = cooldownTimer + Time.deltaTime;

            if (cooldownTimer > cooldown)
            {
                cooldownActive = false;
                cooldownTimer = 0;
            }
        }
    }
}
