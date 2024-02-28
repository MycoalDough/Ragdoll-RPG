using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKingBossEnterance : MonoBehaviour
{
    public KingBoss kingBoss;

    public StartBossAnimation animtaor;
    public GameObject king;

    public PlayerHealth ph;
    public Player player;

    void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        ph = GameObject.FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            ph.gameObject.GetComponent<Animator>().Play("Idle");

            ph.gameObject.GetComponent<Animator>().enabled = false;
            animtaor.kingCam.GetComponent<Animator>().enabled = true;
            player.canMove = false;
            Debug.Log("Close");
            animtaor.kingCam.GetComponent<Animator>().Play("KingBossEnterance");
            animtaor.canvas.GetComponent<Animator>().Play("BossText");
            kingBoss.anim.Play("CloseDoor");
            StartCoroutine(startFight());
        }
    }

    IEnumerator startFight()
    {
        player.death = true;
        yield return new WaitForSeconds(8);
        king.SetActive(true);
        player.death = false;
        animtaor.kingCam.GetComponent<Animator>().enabled = false;
        Destroy(gameObject);
        ph.gameObject.GetComponent<Animator>().enabled = true;

    }
}
