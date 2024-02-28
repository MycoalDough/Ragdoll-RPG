using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour
{

    public bool canSeeInside;

    public GameObject hillOutside;

    public int transperancy = 174;

    public void Start()
    {
        hillOutside.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void Awake()
    {
        hillOutside.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            hillOutside.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            hillOutside.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }

}
