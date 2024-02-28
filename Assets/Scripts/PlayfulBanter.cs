using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayfulBanter : MonoBehaviour
{

    public string[] text;

    public TextMeshPro diolugeBox;

    public int maxTime;
    public float time = 0;

    public int max, min;
    // Start is called before the first frame update
    void Start()
    {
        diolugeBox.gameObject.SetActive(false);
        maxTime = Random.Range(min, max + 1);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time > maxTime)
        {
            maxTime = Random.Range(min, max + 1);
            time = 0;
            StartCoroutine(randomText());
        }
    }

    IEnumerator randomText()
    {
        diolugeBox.gameObject.SetActive(true);
        int randomRange = Random.Range(0, text.Length);
        diolugeBox.text = text[randomRange];
        yield return new WaitForSeconds(2);
        diolugeBox.gameObject.SetActive(false);
    }
}
