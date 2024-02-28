using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    public bool followPlayer = true;
    public CharacterSkinController character;

    // Start is called before the first frame update

    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        if (character.skin == "Marksman")
        {
            gameObject.GetComponent<Camera>().orthographicSize = 11.5f;
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = 9;

        }
    }
    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        character = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!character)
        {
            character = GameObject.FindObjectOfType<CharacterSkinController>().GetComponent<CharacterSkinController>();
        }
        if (followPlayer)
        {
            player.startFollowing = true;
            if (character.skin == "Marksman")
            {
                Camera.main.orthographicSize = 13;
                //gameObject.GetComponent<Camera>().orthographicSize = 13;
            }
            else
            {
                Camera.main.orthographicSize = 9;
                //gameObject.GetComponent<Camera>().orthographicSize = 9;

            }
            if (!followPlayer)
            {
                player.startFollowing = false;

            }



        }
    }
}
