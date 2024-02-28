using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBuddiesTm : MonoBehaviour
{
    public bool marine;

    public GameObject knife;
    public GameObject gun;

    public EnemyController ec;

    public float range;
    public float distance;
    private void Update()
    {
        if(marine)
        {
            distance = Vector3.Distance(transform.position, ec.target.gameObject.transform.position);

            if(distance < range)
            {
                knife.SetActive(true);
                gun.SetActive(false);
                ec.canWalk = true;
            }
            else
            {
                knife.SetActive(false);
                gun.SetActive(true);
            }
        }
        else
        {
            Destroy(gameObject.GetComponent<PlayerBuddiesTm>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
