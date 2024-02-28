using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToss : MonoBehaviour
{
    public float rightSpeed;
    public float upSpeed;

    public bool canShine;
    public GameObject shineShow;
    public FindClosestTarget fctCoin;
    public FindClosestTarget fctEnemy;
    public FindClosestTarget fctEnemy2;

    int multiplier = 0;

    public GameObject parent;

    public LineRenderer line1;
    public LineRenderer line2;
    public GameObject hurtBlock1;
    public GameObject hurtBlock2;

    public LayerMask lm;

    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //fct = gameObject.GetComponent<FindClosestTarget2Tags>();
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightSpeed);
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upSpeed);
        StartCoroutine(timeTilShine());
        //fct.findClosestTarget();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        if(collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "PlayerMelee")
        {
            //Debug.Log("test");
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        
            if(canShine)
            {
                Shine();
            }
            else
            {
                Regular();
            }
        }
    }

    public void Regular()
    {
        if (fctCoin.player)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, fctCoin.player.transform.position, lm);
            line1.gameObject.SetActive(true);
            line1.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
            line1.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
            hurtBlock1.transform.position = hit.point;
            hurtBlock1.SetActive(true);

        }
        else if(fctEnemy.player)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, fctEnemy.player.transform.position , lm);

            line1.gameObject.SetActive(true);
            line1.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
            line1.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
            hurtBlock1.transform.position = hit.point;
            hurtBlock1.SetActive(true);
        }
        StartCoroutine(DestroyAfterTime(1));
    }

    public void Shine()
    {

        if (fctCoin.player)
        {

            RaycastHit2D hit = Physics2D.Linecast(transform.position, fctCoin.player.transform.position, lm);

            line1.gameObject.SetActive(true);
            line1.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
            line1.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
            hurtBlock1.transform.position = hit.point;
            hurtBlock1.SetActive(true);

            if (line1.GetPosition(1) == new Vector3(0, 0, -1))
            {
                line1.gameObject.SetActive(false);
                if (fctEnemy.player)
                {
                    RaycastHit2D hit1 = Physics2D.Linecast(transform.position, fctEnemy.player.transform.position, lm);

                    line1.gameObject.SetActive(true);
                    line1.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
                    line1.SetPosition(1, new Vector3(hit1.point.x, hit1.point.y, -1));
                    hurtBlock1.transform.position = hit1.point;
                    hurtBlock1.SetActive(true);
                }
            }
        }
        else if (fctEnemy.player)
        {
            RaycastHit2D hit1 = Physics2D.Linecast(transform.position, fctEnemy.player.transform.position, lm);

            line1.gameObject.SetActive(true);
            line1.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
            line1.SetPosition(1, new Vector3(hit1.point.x, hit1.point.y, -1));
            hurtBlock1.transform.position = hit1.point;
            hurtBlock1.SetActive(true);
        }
        //---------------------2nd hit---------------------------//

        if (fctEnemy2.player)
        {
            RaycastHit2D hit2 = Physics2D.Linecast(transform.position, fctEnemy2.player.transform.position, lm);

            line2.gameObject.SetActive(true);
            line2.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
            line2.SetPosition(1, new Vector3(hit2.point.x, hit2.point.y, -1));
            hurtBlock2.transform.position = hit2.point;
            hurtBlock2.SetActive(true);
        }
        StartCoroutine(DestroyAfterTime(1));
    }


    IEnumerator DestroyAfterTime(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(parent);
    }

    IEnumerator timeTilShine()
    {
        shineShow.SetActive(false);
        float time = Random.Range(0.5f, 1.3f);
        yield return new WaitForSeconds(time);
        canShine = true;
        shineShow.SetActive(true);
        yield return new WaitForSeconds(1f);
        canShine = false;
        shineShow.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(parent);
    }
}
