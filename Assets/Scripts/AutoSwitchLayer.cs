using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSwitchLayer : MonoBehaviour
{
    public int firstLayer;
    public int time;
    public int layerToSwitch;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(switchLayer());
    }

    IEnumerator switchLayer()
    {
        gameObject.layer = firstLayer;
        yield return new WaitForSeconds(time);
        gameObject.layer = layerToSwitch;
    }
}
