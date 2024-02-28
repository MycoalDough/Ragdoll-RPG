using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPotion : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            StartCoroutine(player.ShieldPotion());
            gameObject.layer = 11;
        }
    }
}
