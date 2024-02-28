using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    public Camera cam;

    public float force = 100;

    public float floating = 1f;

    public Vector2 mousePos;

    public float cooldown = 5f;
    [SerializeField] private float cooldownTimer = 0f;
    [SerializeField] private bool cooldownActive = false;


    public KeyCode buttonToPress = KeyCode.E;
    public ToolDurability dur;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
    }
    private void OnLevelWasLoaded(int level)
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
    }

    private void Awake()
    {
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cam == null)
        {
            cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        }
        mousePos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 forceAdd = mousePos - new Vector2(transform.position.x, transform.position.y);

        if (Input.GetKeyDown(buttonToPress))
        {
            if(!cooldownActive)
            {
                if (gameObject.GetComponent<FixedJoint2D>() != null)
                {
                    if(dur)
                    {
                        dur.Durability(1);

                    }
                    cooldownTimer = 0;
                    cooldownActive = true;
                    //gameObject.GetComponent<Rigidbody2D>().velocity = (mousePos * force);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(forceAdd * force);
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(gameObject.GetComponent<Rigidbody2D>().velocity, 1);


                }
            }
        }

        if(gameObject.GetComponent<Rigidbody2D>().velocity.x > 5)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 10)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 9);
        }


        if(cooldownActive)
        {
            cooldownTimer = cooldownTimer + Time.deltaTime;

            if(cooldownTimer > cooldown)
            {
                cooldownActive = false;
                cooldownTimer = 0;
            }
        }
    }



}

