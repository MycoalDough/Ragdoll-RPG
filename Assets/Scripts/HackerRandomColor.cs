using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerRandomColor : MonoBehaviour
{

    public SpriteRenderer sr;
    public float time, maxTime;

    public bool dmg;

    public Sprite[] setArray;

    public void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private Color32 GetRandomColour32()
    {
        //using Color32
        return new Color32(
          (byte)UnityEngine.Random.Range(0, 255), //Red
          (byte)UnityEngine.Random.Range(0, 255), //Green
          (byte)UnityEngine.Random.Range(0, 255), //Blue
          255 //Alpha (transparency)
        );
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(dmg)
        {
            if (transform.parent.gameObject.GetComponent<HealthAIManager>())
            {
                transform.parent.gameObject.GetComponent<HealthAIManager>().healthSystem.Damage(Random.Range(-1, 3));

            }

        }
        if (maxTime < time)
        {
            time = 0;
            maxTime = Random.Range(0.0f, 2.0f);
            sr.color = GetRandomColour32();
            sr.sprite = setArray[Random.Range(0, setArray.Length)];
        }
    }
}
