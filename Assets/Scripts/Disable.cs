using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{

    public float timeToDisable;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disable());
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }
}
