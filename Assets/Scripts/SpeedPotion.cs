using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            StartCoroutine(player.speedPotionCount());
            gameObject.layer = 11;
        }
    }


}
