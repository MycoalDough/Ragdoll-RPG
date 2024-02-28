using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactGround : MonoBehaviour
{

    public GameObject impact;
    public LayerMask layerMask;
    public bool checkIfTrig;
    public int velocity;
    public bool useVelocity;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(checkIfTrig)
        {
            if(useVelocity)
            {
                if(gameObject.GetComponent<Rigidbody2D>().velocity.x >= velocity || gameObject.GetComponent<Rigidbody2D>().velocity.x <= -velocity)
                {
                    if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
                    {
                        Instantiate(impact, gameObject.transform.position, impact.gameObject.transform.rotation);
                    }
                }
            }
            else
            {
                if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
                {
                    Instantiate(impact, gameObject.transform.position, impact.gameObject.transform.rotation);
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!checkIfTrig)
        {
            if (useVelocity)
            {
                if (gameObject.GetComponent<Rigidbody2D>().velocity.x >= velocity || gameObject.GetComponent<Rigidbody2D>().velocity.x <= -velocity)
                {
                    if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
                    {
                        Instantiate(impact, gameObject.transform.position, impact.gameObject.transform.rotation);
                    }
                }
            }
            else
            {
                if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
                {
                    Instantiate(impact, gameObject.transform.position, impact.gameObject.transform.rotation);
                }
            }

        }
    }
}
