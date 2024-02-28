using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool death = false;
    public GameObject player;

    public GameObject blindCanvas;

    public bool canMove = true;
    private bool balloon;
    public CurrencyManager currencyManager;
    [SerializeField] private CharacterSkinController csc;

    [Header("Movement")]
    public float movementSpeed;
    public float jumpForce;
    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    public bool isRagdoll;
    [SerializeField] private bool canSpeed;
    // Start is called before the first frame update

    [Header("Camera Follow")]
    public bool startFollowing = true;
    public Camera cam;
    [Range(0f, 1f)] public float interpolation;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    [Header("Animation")]
    public Animator anim;
    public GameObject shield;
    public bool ironSheild = false;

    [Header("Spawning")]
    public Vector3 scale;
    private int db = 0;
    private int dbBlind = 0;
    public GameObject[] body;

    
    void Awake()
    {
        canSpeed = true;
        DontDestroyOnLoad(player);
        shield.SetActive(false);
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim.StopPlayback();
        spawnIn();


    }


    void OnLevelWasLoaded(int level)
    {
        blindCanvas.SetActive(false);
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        spawnIn();
        ironSheild = false;
        movementSpeed = 300;
        shield.SetActive(false);

    }


    void spawnIn()
    {
        anim.Play("EnterWorld");
        Debug.Log("Spawn In");
        player.transform.position = new Vector2(-12.29f, 0.11f);
        for (int i = 0; i < body.Length; i++)
        {
            body[i].transform.position = new Vector2(-12, 2);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.parent.position = transform.position - transform.localPosition;

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 20)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 19);
        }

        if(canMove)
        {
            Movement();
            Jump();
            CameraFollow();
        }


    }

    private void Update()
    {
            if (isRagdoll)
            {
                death = true;
            }
            else if (!isRagdoll)
            {
                death = false;
            }
    }


    public void Movement()
    {
        if(!death)
        {
            float xDirection = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xDirection * (movementSpeed * Time.deltaTime), rb.velocity.y);
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("Walk Back");
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                anim.Play("Walk");
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                anim.Play("Idle");
            }

        }

    }

    public void shady()
    {
        StartCoroutine(shadyMushroom());
    }

    public void blind()
    {
        StartCoroutine(blindBerry());
    }

    public IEnumerator shadyMushroom()
    {
        if(db == 0)
        {
            db = 1;
            int ranged = Random.Range(0, 4);
            if (ranged == 2)
            {
                for (int i = 0; i < body.Length; i++)
                {
                    body[i].transform.localScale = new Vector2(body[i].transform.localScale.x * 2, body[i].transform.localScale.y * 2);

                }

                yield return new WaitForSeconds(10);
                for (int i = 0; i < body.Length; i++)
                {
                    body[i].transform.localScale = new Vector2(body[i].transform.localScale.x / 2, body[i].transform.localScale.y / 2);
                }

            }
            else
            {
                int random = Random.Range(0, body.Length);


                scale = body[random].transform.localScale;

                body[random].transform.localScale = new Vector2(body[random].transform.localScale.x * 2, body[random].transform.localScale.y * 2);
                yield return new WaitForSeconds(10);
                body[random].transform.localScale = scale;
            }

            db = 0;
        }
        


    }

    public IEnumerator blindBerry()
    {
        if (dbBlind == 0)
        {
            dbBlind = 1;

            blindCanvas.SetActive(true);
            yield return new WaitForSeconds(8);
            blindCanvas.SetActive(false);

            dbBlind = 0;
        }
    }

    private void OnDestroy()
    {
        SaveSystem.SavePlayer(currencyManager);
    }

    public IEnumerator speedPotionCount()
    {
        if(canSpeed)
        {
            canSpeed = false;
            movementSpeed = movementSpeed * 1.7f;
            yield return new WaitForSeconds(10);
            movementSpeed = movementSpeed / 1.7f;
            canSpeed = true;

        }

    }

    public IEnumerator ShieldPotion()
    {
        ironSheild = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(7);
        shield.SetActive(false);
        ironSheild = false;
    }

    public void Jump()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) && !death)
        {
            if(isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
    
    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;

    }

    private void CameraFollow()
    {
        if(cam && cam.gameObject.GetComponent<Animator>())
        {
            if (startFollowing && cam.gameObject.GetComponent<Animator>().enabled == false)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, interpolation);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, raycastDistance);
    }

    public void balloonCD(GameObject balloonC, GameObject spawnPos)
    {
        if (!balloon)
        {
            balloon = true;
            GameObject balloonClone = Instantiate(balloonC, spawnPos.transform.position, balloonC.transform.rotation);
            balloonClone.GetComponent<DistanceJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(balloonCount());
        }
    }
    IEnumerator balloonCount()
    {
        yield return new WaitForSeconds(0.01f);
        balloon = false;
    }
}
