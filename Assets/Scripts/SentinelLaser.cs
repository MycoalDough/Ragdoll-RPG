using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelLaser : MonoBehaviour
{
    [Header("Laser")]
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    Transform _transform;
    public PlayerHealth ph;

    [Header("LaserFire")]
    public float maxTimeTilFire = 5, timeTilFire = 0;
    public float maxTimeForFiring = 6, timeFiring = 0;
    public GameObject reloadEffect;
    public bool firing = false;
    public bool effect = false;


    [Header("Target")]
    //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public EnemyRange er;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        //rotateTowardsTarget();

        //if(!firing)
        //{
        //    if(!effect)
        //    {
        //        effect = true;
        //        Instantiate(reloadEffect, gameObject.transform.position, reloadEffect.transform.rotation);
        //    }
        //    timeTilFire = timeTilFire + Time.deltaTime;

        //    if(maxTimeTilFire < timeTilFire)
        //    {
        //        firing = true;
        //        timeTilFire = 0;
        //        effect = false;
        //    }
        //}
        //else if(firing)
        //{
        //    if(maxTimeForFiring > timeFiring)
        //    {
        //        shootLaser();
        //    }
        //    timeFiring = timeFiring + Time.deltaTime;
        //    if (maxTimeForFiring < timeFiring)
        //    {
        //        firing = false;
        //        timeFiring = 0;
        //    }
        //}

        shootLaser();

        if (!ph)
        {
            ph = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();

        }
    }

    void shootLaser()
    {
        if(er.inRange)
        {
            gameObject.GetComponent<LineRenderer>().enabled = true;

            if (Physics2D.Raycast(transform.position, transform.right, defDistanceRay))
            {
                RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
                Draw2DRay(laserFirePoint.position, hit.point);
                if (hit.transform.gameObject.layer == 8)
                {
                    //Debug.Log("AAA");
                    ph.Damage(1);
                }
            }
            else
            {
                Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
                //Debug.Log("brtuh");
            }
        }
        else
        {
            gameObject.GetComponent<LineRenderer>().enabled = false;
        }
    }

    void rotateTowardsTarget()
    {
        Vector3 targ = Target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
