using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{

    public float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    public float yAxis;

    public bool initialOverride = false;
    // Start is called before the first frame update
    void Start()
    {
        yAxis = transform.position.y;
        if (initialOverride == false)
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, yAxis, transform.position.z);


        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
