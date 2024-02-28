using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : MonoBehaviour
{

    public bool touchPlayer = false;
    public float destoryAfterTime = 30f;
    public bool changeRotation = false;

    public bool candestroy = true;
    public bool destroyOnGround = true;

    public bool trigger = false;

    public float yVal;
    public GameObject destroyOther;

    public GameObject createNew;

    public void Start()
    {
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        StartCoroutine(destroyAfterTime());

        if(changeRotation)
        {
            gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, gameObject.GetComponent<Transform>().rotation.z);
        }

        if(yVal != 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yVal);
        }
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(destoryAfterTime);
        delete();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(candestroy)
        {
            if (touchPlayer)
            {
                if (collision.gameObject.tag == "collideHeal")
                {
                    delete();
                }
            }
            else
            {
                if (!gameObject.GetComponent<BounceEffect>())
                {
                    if (destroyOnGround)
                    {
                        delete();
                    }
                    else
                    {
                        if (collision.gameObject.layer != 9)
                        {
                            delete();
                        }
                    }
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            delete();
        }
    }

    private void delete()
    {
        if(createNew)
        {
            create();
        }
        else
        {
            if (destroyOther)
            {
                Destroy(destroyOther);
            }
            Destroy(gameObject);
        }


    }

    private void create()
    {
        if (createNew)
        {
            Instantiate(createNew, gameObject.transform.position, Quaternion.identity);
        }

        if (destroyOther)
        {
            Destroy(destroyOther);
        }
        Destroy(gameObject);


    }

}
