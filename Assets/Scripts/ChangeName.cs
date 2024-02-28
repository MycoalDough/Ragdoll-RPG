using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{

    public string ToRemove = "Placeholder";
    // Start is called before the first frame update
    void Start()
    {
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        if(ToRemove != "Placeholder")
        {
            transform.name = transform.name.Replace(ToRemove, "").Trim();

        }


    }

}
