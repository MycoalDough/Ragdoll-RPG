using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveTowards : MonoBehaviour
{
    public float attractionSpeed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("collideHeal"))
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, attractionSpeed * Time.deltaTime);
        }
    }
}
