using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautEnterance : MonoBehaviour
{

    public JuggernautController omegaBoss;

    public StartBossAnimation animtaor;

    public PlayerHealth ph;
    public GameObject king;

    public GameObject jugg;

    public Player player;

    public GameObject blockade;

    public GameObject door;
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
            player.death = true;
            player.canMove = false;
            Debug.Log("Close");
            animtaor.kingCam.GetComponent<Animator>().Play("OmegaBossEnterance");
            animtaor.canvas.GetComponent<Animator>().Play("BossText");
            door.GetComponent<Animator>().Play("CloseDoorOmega");
            StartCoroutine(startFight());
        }
    }

    IEnumerator startFight()
    {

        player.death = true;
        yield return new WaitForSeconds(3.1f);
        //animtaor.kingCam.GetComponent<Animator>().enabled = false;
        animtaor.kingCam.GetComponent<CameraController>().followPlayer = false;
        yield return new WaitForSeconds(2.9f);
        animtaor.kingCam.GetComponent<CameraController>().followPlayer = false;
        jugg.gameObject.GetComponent<EnemyController>().start = true;
        jugg.gameObject.GetComponent<EnemyController>().canWalk = true;
        jugg.gameObject.GetComponent<Animator>().enabled = true;
        blockade.SetActive(false);
        king.SetActive(true);
        ph.gameObject.GetComponent<Animator>().enabled = true;

        player.death = false;
        player.canMove = true;
        animtaor.kingCam.GetComponent<Animator>().enabled = false;


        Destroy(gameObject);
    }
}
