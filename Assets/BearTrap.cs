using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public Ragdoll r;

    public GameObject trap;
    public GameObject trapSetOff;

    public Transform p;

    private bool db;

    public PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.FindObjectOfType<Ragdoll>().GetComponent<Ragdoll>();
        ph = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal" && !db)
        {
            StartCoroutine(Trapped());
        }
    }

    IEnumerator Trapped()
    {
        db = true;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        r.RDable[6].transform.eulerAngles = new Vector3(0, 0, 180);
        r.RDable[6].transform.position = p.position;

        FixedJoint2D fj = r.RDable[6].AddComponent<FixedJoint2D>();

        ph.Damage(10);
        trap.SetActive(false);
        trapSetOff.SetActive(true);
        r.RagdollLock();
        yield return new WaitForSeconds(1);
        r.RagdollLock();
        yield return new WaitForSeconds(1);
        trapSetOff.SetActive(false);
        Destroy(fj);
    }
}
