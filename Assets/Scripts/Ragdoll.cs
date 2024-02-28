using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public List<GameObject> RDable = new List<GameObject>();
    public bool isRagdolled = false;
    public bool ragdollLock = false;
    public GameObject plrManager;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in gameObject.transform)
        {
            if(child.gameObject.GetComponent<Balance>())
            {
                RDable.Add(child.gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !ragdollLock && plrManager && plrManager.GetComponent<Player>())
        {
            if(!isRagdolled)
            {
                plrManager.GetComponent<Player>().isRagdoll = true;
                for (int i = 0; i < RDable.Count; i++)
                {
                    RDable[i].gameObject.GetComponent<Balance>().force = 0;
                }
                isRagdolled = true;
            }
            else if (isRagdolled)
            {
                plrManager.GetComponent<Player>().isRagdoll = false;
                for (int i = 0; i < RDable.Count; i++)
                {
                    RDable[i].gameObject.GetComponent<Balance>().force = RDable[i].gameObject.GetComponent<Balance>().savedForce;
                }
                isRagdolled = false;
            }
        }
    }

    public void ragdoll()
    {
        plrManager.GetComponent<Player>().isRagdoll = false;
        for (int i = 0; i < RDable.Count; i++)
        {
            RDable[i].gameObject.GetComponent<Balance>().force = 0;
        }
        isRagdolled = true;
    }

    public void RagdollLock()
    {
        StartCoroutine(ragdollLockCD());
    }

    IEnumerator ragdollLockCD()
    {
        if(plrManager.GetComponent<Player>())
        {
            plrManager.GetComponent<Player>().isRagdoll = true;
        }
        plrManager.GetComponent<Player>().isRagdoll = true;
        ragdollLock = true;
        for (int i = 0; i < RDable.Count; i++)
        {
            RDable[i].gameObject.GetComponent<Balance>().force = 0;
        }
        isRagdolled = true;
        
        yield return new WaitForSeconds(2);
        plrManager.GetComponent<Player>().isRagdoll = false;
        for (int i = 0; i < RDable.Count; i++)
        {
            RDable[i].gameObject.GetComponent<Balance>().force = RDable[i].gameObject.GetComponent<Balance>().savedForce;
        }
        isRagdolled = false;
        
        ragdollLock = false;
    }



}
