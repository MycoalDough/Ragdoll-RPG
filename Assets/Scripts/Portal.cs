using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{

    public int[] iLevelToLoad;
    public string[] sLevelToLoad;

    public bool useIntegerToLoadLevel = true;
    public bool useKey = false;
    public bool canEnter = false;

    public string nextLevelAfterUpgrade;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collideHeal")
        {
            canEnter = true;

            if (!useKey)
            {
                LoadScene();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canEnter = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && canEnter)
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        if(nextLevelAfterUpgrade != null)
        {
            UpgradeManagerCanvas.sLevelToLoad = nextLevelAfterUpgrade;
            SceneManager.LoadScene(sLevelToLoad[Random.Range(0, sLevelToLoad.Length)]);
        }
        else
        {
            if (useIntegerToLoadLevel)
            {
                SceneManager.LoadScene(iLevelToLoad[Random.Range(0, iLevelToLoad.Length)]);
            }
            else
            {
                SceneManager.LoadScene(sLevelToLoad[Random.Range(0, sLevelToLoad.Length)]);

            }
        }
    }
}
