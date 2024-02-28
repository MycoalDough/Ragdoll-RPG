using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobShot : MonoBehaviour
{
    [Header("Config")]
    public float speed;
    public Transform spawnPos;

    [Header("Arc Shot")]
    public bool shootUsingArc = true;
    public GameObject target;
    public Vector3 targ;

    private float spawnPosX;
    private float targetX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    public float heightVal = 2;

    private void Start()
    {
        targ = target.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Ragdoll>())
        {
            collision.gameObject.GetComponentInParent<Ragdoll>().RagdollLock();
        }
    }

    private void Update()
    {
        lobShot();
    }


    public void lobShot()
    {
        if (shootUsingArc)
        {
            spawnPosX = spawnPos.transform.position.x;
            targetX = targ.x;

            dist = targetX - spawnPosX;
            nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
            baseY = Mathf.Lerp(spawnPos.transform.position.y, -6, (nextX - spawnPosX) / dist);
            height = heightVal * (nextX - spawnPosX) * (nextX - targetX) / (-0.25f * dist * dist);

            Vector3 movePos = new Vector3(nextX, baseY + height, transform.position.z);
            transform.rotation = lookAtTarget(movePos - transform.position);
            transform.position = movePos;
        }
    }

    public static Quaternion lookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }



}
