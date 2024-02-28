using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutationSiren : MonoBehaviour
{
    public float maxTime, time;

    public float fieldOfInpact;
    public LayerMask LayerDetection;

    public SpriteRenderer range;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (maxTime < time)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                range.enabled = (true);
                time = 0;
                Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfInpact, LayerDetection);

                foreach (Collider2D obj in objects)
                {
                    if (obj.gameObject.layer == 17)
                    {
                        int dmg = int.Parse(obj.gameObject.name);
                        int reduced = Mathf.RoundToInt(dmg / 1.5f);
                        obj.gameObject.name = reduced.ToString();
                    }
                    obj.transform.localScale = new Vector2(obj.transform.localScale.x / 1.5f, obj.transform.localScale.y / 1.5f);

                    foreach (Transform child in obj.gameObject.transform)
                    {
                        if (child.gameObject.layer == 17)
                        {
                            int dmg = int.Parse(child.gameObject.name);
                            int reduced = Mathf.RoundToInt(dmg / 1.5f);
                            child.gameObject.name = reduced.ToString();
                        }
                    }
                }
                Instantiate(zombie, gameObject.transform.position, Quaternion.identity);
            }

        }
        else
        {
            range.enabled = (false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfInpact);
    }
}
