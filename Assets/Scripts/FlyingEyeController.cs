using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeController : MonoBehaviour
{
    public EnemyController enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(enemy.target.gameObject.transform);
    }
}
