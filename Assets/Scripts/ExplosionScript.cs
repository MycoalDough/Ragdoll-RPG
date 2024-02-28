using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float fieldOfInpact;
    public float force;
    public LayerMask LayerDetection;
    public GameObject explosionEffect;

    public bool collideWithGround = true;
    public PlayerHealth health;

    public bool antiPlayer = true;

    public void Awake()
    {
        health = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(antiPlayer)
        {
            if(collision.gameObject.tag == "collideHeal")
            {
                Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfInpact, LayerDetection);

                foreach (Collider2D obj in objects)
                {
                    Vector2 direction = obj.transform.position - transform.position;
                    if(obj.GetComponentInParent<Ragdoll>() && obj.GetComponent<Rigidbody2D>())
                    {
                        obj.GetComponentInParent<Ragdoll>().RagdollLock();
                        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force / 5);
                    }



                }
                GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(ExplosionEffectIns, 1);
                health.Damage(10);
                Destroy(gameObject);
            }

        }

        else if(!antiPlayer)
        {
            if (collision.gameObject.layer == 10)
            {
                Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfInpact, LayerDetection);

                foreach (Collider2D obj in objects)
                {
                    Vector2 direction = obj.transform.position - transform.position;
                    if(obj.GetComponent<Rigidbody2D>())
                    {
                        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force / 5);
                    }


                }
                GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(ExplosionEffectIns, 1);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.layer == 9 && collideWithGround == true)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfInpact, LayerDetection);

            foreach (Collider2D obj in objects)
            {
                if(obj.GetComponent<Rigidbody2D>())
                {
                    Vector2 direction = obj.transform.position - transform.position;

                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force / 5);
                }

            }
            if (!gameObject.GetComponent<BounceEffect>())
            {
                GameObject ExplosionEffectIns1 = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(ExplosionEffectIns1, 1);
                Destroy(gameObject);
            }

        }

        if(!gameObject.GetComponent<BounceEffect>())
        {
                GameObject ExplosionEffectIns1 = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(ExplosionEffectIns1, 1);
                Destroy(gameObject);
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfInpact);
    }

}
