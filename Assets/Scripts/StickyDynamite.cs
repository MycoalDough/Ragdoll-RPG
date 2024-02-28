using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyDynamite : MonoBehaviour
{
    public FixedJoint2D fj;
    public GameObject expEffect;
    public void Awake()
    {
        fj = gameObject.GetComponent<FixedJoint2D>();
        fj.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fj.enabled = true;
        enabled = true;
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(connect());
        }
        IEnumerator connect()
        {
            yield return new WaitForSeconds(2);
            gameObject.name = "100";
            ExplosionScript exp = gameObject.AddComponent<ExplosionScript>();
            exp.antiPlayer = false;
            exp.explosionEffect = expEffect;
            exp.fieldOfInpact = 1f;

            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<FixedJoint2D>().enabled = false;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);

            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<Collider2D>().enabled = true;

            //change variables

        }
    }
}
