using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour
{
    public EnchantTool enchant;
    public GameObject fire;
    public bool flame = false;

    [Header("Timer")]
    public float time = 0;
    public float maxTime = 2;
    public bool canFlame = false;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time < maxTime)
        {
            time = time + Time.deltaTime;

        }

        if (time >= maxTime && canFlame == false)
        {
            canFlame = true;
            time = 0;
        }
        if(enchant.enchants[1] == true)
        {
            particle.SetActive(true);
            flame = true;
        }
        else
        {
            particle.SetActive(false);
            flame = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(flame && canFlame && collision.gameObject.layer == 10)
        {
            GameObject spawn = Instantiate(fire, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            spawn.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            canFlame = false;
            time = 0;

        }
    }
}
