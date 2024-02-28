using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public int isLeftOrRight; //0 for left, 1 for right
    public float speed = 300f;
    public Camera cam;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();

    }
    private void OnLevelWasLoaded(int level)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        Vector3 difference = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

        if(Input.GetMouseButton(isLeftOrRight))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.deltaTime));
        }
    }
}
