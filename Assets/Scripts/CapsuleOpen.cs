using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CapsuleOpen : MonoBehaviour
{

    [Header("Capsule")]
    public bool common = false;
    public bool rare = false;
    public bool epic = false;
    public bool legendary = false;
    public bool mythic = false;

    [Header("Cards")]
    public int commoncards;
    public int rarecards;
    public int epiccards;
    public int legendarycards;
    public int mythicalcards;

    public Sprite[] commonImages; //put in order!!!
    public Sprite[] rareImages;
    public Sprite[] epicImages;
    public Sprite[] legendaryImages;
    public Sprite[] mythicImages;


    public int rngCards;

    public TextMeshPro description;
    public SpriteRenderer image;

    [Header("Settings")]
    public int rerolls;
    public int commonTokens;
    public int rareTokens;
    public int epicTokens;
    public int legendaryTokens;
    public int mythicalTokens;

    public Animator anim;
    public CurrencyManager currencyManager;

    public Sprite tokens;

    public bool debounce = false;

    public bool exit = false;

    public GameObject canvas;



    private void Start()
    {
        currencyManager = GameObject.FindObjectOfType<CurrencyManager>().GetComponent<CurrencyManager>();
    }
    // Update is called once per frame
    void Update()
    {

        if (currencyManager)
        {
            if(!debounce)
            {
                Purchased();
                debounce = true;
                StartCoroutine(openCapsule());
            }
        }

        if (exit == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                canvas.SetActive(true);
                gameObject.SetActive(false);

            }
        }
    }

    public void Purchased()
    {
        rerolls = 5;
        anim.Play("OpenCapsule");

        if(common) //75 chance of common, 20 for rare, 5 for epic
        {
            int rng = Random.Range(1, 100);

            if(rng <= 75)
            {
                commonCard();
            }
            else if(rng < 96 && rng > 76)
            {
                rareCard();
            }
            else if(rng < 101 && rng > 95)
            {
                epicCard();
            }
        }

        else if (rare) //50 chance of common, 35 for rare, 15 for epic
        {
            int rng = Random.Range(1, 100);

            if (rng <= 50)
            {
                commonCard();
            }
            else if (rng < 86 && rng > 50)
            {
                rareCard();
            }
            else if (rng < 101 && rng > 86)
            {
                epicCard();
            }
        }

        else if (epic) //35 chance of common, 30 for rare, 25 for epic, 10 legendary
        {
            int rng = Random.Range(1, 100);

            if (rng <= 35)
            {
                commonCard();
            }
            else if (rng < 66 && rng > 35)
            {
                rareCard();
            }
            else if (rng < 91 && rng > 66)
            {
                epicCard();
            }
            else if(rng < 101 && rng < 91)
            {
                legendaryCard();
            }
        }

        else if (legendary) //10 chance of common, 35 for rare, 30 for epic, 15 legendary, 10 for mythic
        {
            int rng = Random.Range(1, 100);

            if (rng <= 10)
            {
                commonCard();
            }
            else if (rng < 46 && rng > 10)
            {
                rareCard();
            }
            else if (rng < 76 && rng > 46)
            {
                epicCard();
            }
            else if (rng < 91 && rng < 76)
            {
                legendaryCard();
            }
            else if (rng < 101 && rng < 91)
            {
                mythicalCard();
            }
        }

        else if (mythic) //50 for epic, 30 legendary, 20 mythic
        {
            int rng = Random.Range(1, 100);

            if (rng <= 50)
            {
                epicCard();
            }
            else if (rng < 81 && rng > 50)
            {
                legendaryCard();
            }
            else if (rng < 101 && rng > 81)
            {
                mythicalCard();
            }
        }

    }

    public void commonCard() //currently 6 commons
    {
        int rngCardsC = Random.Range(1, commoncards + 1);
        Debug.Log(rngCardsC);
        if(rngCardsC == 1)
        {
            if(currencyManager.medic == false)
            {
                currencyManager.medic = true;
                description.text = "Medic";
                image.sprite = commonImages[0];
            }
            else
            {
                if(rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
        else if(rngCardsC == 2)
        {
            if (currencyManager.boxer == false)
            {
                currencyManager.boxer = true;
                description.text = "Boxer";
                image.sprite = commonImages[1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsC == 3)
        {
            if (currencyManager.knight == false)
            {
                currencyManager.knight = true;
                description.text = "Knight";
                image.sprite = commonImages[2];
            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsC == 4)
        {
            if (currencyManager.wizard == false)
            {
                currencyManager.wizard = true;
                description.text = "Wizard";
                image.sprite = commonImages[3];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
        else if (rngCardsC == 5)
        {
            if (currencyManager.gardener == false)
            {
                currencyManager.gardener = true;
                description.text = "Gardener";
                image.sprite = commonImages[4];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
        else if (rngCardsC == 6)
        {
            if (currencyManager.archer == false)
            {
                currencyManager.archer = true;
                description.text = "Archer";
                image.sprite = commonImages[5];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsC = Random.Range(1, commoncards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    commonCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + commonTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
    }

    public void rareCard() //currently 4 rares
    {
        int rngCardsR = Random.Range(1, rarecards + 1);

        if (rngCardsR == 1)
        {
            if (currencyManager.marksman == false)
            {
                currencyManager.marksman = true;
                description.text = "Marksman";
                image.sprite = rareImages[0];


            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsR = Random.Range(1, rarecards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    rareCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + rareTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsR == 2)
        {
            if (currencyManager.ninja == false)
            {
                currencyManager.ninja = true;
                description.text = "Ninja";
                image.sprite = rareImages[1];


            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsR = Random.Range(1, rarecards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    rareCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + rareTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
        else if (rngCardsR == 3)
        {
            if (currencyManager.engineer == false)
            {
                currencyManager.engineer = true;
                description.text = "Engineer";
                image.sprite = rareImages[2];


            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsR = Random.Range(1, rarecards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    rareCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + rareTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
        else if (rngCardsR == 4)
        {
            if (currencyManager.kog == false)
            {
                description.text = "King of Gold";

                currencyManager.kog = true;
                image.sprite = rareImages[rngCardsR - 1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsR = Random.Range(1, rarecards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    rareCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + rareTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
       
    }

    public void epicCard() //currently 5 epics
    {
        int rngCardsE = Random.Range(1, epiccards + 1);

        if (rngCardsE == 1)
        {
            if (currencyManager.berserker == false)
            {
                currencyManager.berserker = true;
                description.text = "Berserker";
                image.sprite = epicImages[rngCardsE - 1];


            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsE = Random.Range(1, epiccards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    epicCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + epicTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsE == 2)
        {
            if (currencyManager.necromancer == false)
            {
                image.sprite = epicImages[rngCardsE - 1];

                currencyManager.necromancer = true;
                description.text = "Necromancer";

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsE = Random.Range(1, epiccards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    epicCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + epicTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsE == 3)
        {
            if (currencyManager.golem == false)
            {
                description.text = "Golem";
                image.sprite = epicImages[rngCardsE - 1];

                currencyManager.golem = true;
            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsE = Random.Range(1, epiccards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    epicCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + epicTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsE == 4)
        {
            if (currencyManager.bounty == false)
            {
                description.text = "Bounty Hunter";
                image.sprite = epicImages[rngCardsE - 1];

                currencyManager.bounty = true;
            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsE = Random.Range(1, epiccards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    epicCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + epicTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsE == 5)
        {
            if (currencyManager.sheild == false)
            {
                description.text = "Forcefield";
                image.sprite = epicImages[rngCardsE - 1];

                currencyManager.sheild = true;
            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsE = Random.Range(1, epiccards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    epicCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + epicTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        
    }

    public void legendaryCard() //currently 3 legendaries
    {
        int rngCardsL = Random.Range(1, legendarycards + 1);

        if (rngCardsL == 1)
        {
            if (currencyManager.giant == false)
            {
                currencyManager.giant = true;
                description.text = "Giant"; 
                image.sprite = legendaryImages[rngCardsL - 1];


            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsL = Random.Range(1, legendarycards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    legendaryCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + legendaryTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsL == 2)
        {
            if (currencyManager.hacker == false)
            {
                currencyManager.hacker = true;
                description.text = "Hacker";
                image.sprite = legendaryImages[rngCardsL - 1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsL = Random.Range(1, legendarycards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    legendaryCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + legendaryTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsL == 3)
        {
            if (currencyManager.enchanter == false)
            {
                currencyManager.enchanter = true;
                description.text = "Enchanter";
                image.sprite = legendaryImages[rngCardsL - 1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsL = Random.Range(1, legendarycards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    legendaryCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + legendaryTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
    }

    public void mythicalCard() //currently 2 mythics
    {
        int rngCardsM= Random.Range(1, mythicalcards + 1);

        if (rngCardsM== 1)
        {
            if (currencyManager.alchemist == false)
            {
                currencyManager.alchemist = true;
                description.text = "Alchemist";
                image.sprite = mythicImages[rngCardsM- 1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsM = Random.Range(1, mythicalcards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    mythicalCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + mythicalTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;                    //return;
                }
            }
        }
        else if (rngCardsM == 2)
        {
            if (currencyManager.angel == false)
            {
                currencyManager.angel = true;
                description.text = "Angel";
                image.sprite = mythicImages[rngCardsM - 1];

            }
            else
            {
                if (rerolls != 0)
                {
                    rngCardsM = Random.Range(1, mythicalcards + 1);
                    rerolls--;
                    Debug.Log("Reroll");
                    mythicalCard();
                    //return;
                }
                else
                {
                    currencyManager.tokens = currencyManager.tokens + mythicalTokens;
                    description.text = "Tokens";
                    image.sprite = tokens;
                }
            }
        }
    }


    IEnumerator openCapsule()
    {
        yield return new WaitForSeconds(0.01f);
        anim.Play("OpenCapsule");
        yield return new WaitForSeconds(5.5f);
        exit = true;


    }
}
