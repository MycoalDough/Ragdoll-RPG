using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRodCloud : MonoBehaviour
{
    [Header("Timers")]
    public float timeR, maxTimeR;
    public float timeL, maxTimeL;

    public GameObject rain;
    public GameObject lightning;

    public bool moveLeft;

    void Start()
    {
        StartCoroutine(destroyAfterTime());
        
    }

    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, 3);
        //movement, determines left or right
        if (moveLeft)
        {
            //moveLeft
        }
        else if (!moveLeft)
        {
            //moveRight
        }

        //rainTime
        if (timeR < maxTimeR)
        {
            timeR = timeR + Time.deltaTime;
        }
        else
        {
            timeR = 0;
            Instantiate(rain, gameObject.transform.position + new Vector3(Random.Range(-2,2),0,0), Quaternion.identity);
        }

        //lightning time
        if (timeL < maxTimeL)
        {
            timeL = timeL + Time.deltaTime;
        }
        else
        {
            timeL = 0;
            Instantiate(lightning, gameObject.transform.position + new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity);
        }
    }


    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
