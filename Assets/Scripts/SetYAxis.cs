using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetYAxis : MonoBehaviour
{
    public float YAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, YAxis);
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
