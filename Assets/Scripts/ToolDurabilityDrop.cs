using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDurabilityDrop : MonoBehaviour
{
    public int uses;

    public int maxUses;

    public int number;

    public bool[] enchants;

    private bool premiumQualityDB;
    public UpgradeManager um;

    public void Awake()
    {
        um = GameObject.FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>();
        if(um.premiumQuality && !premiumQualityDB)
        {
            maxUses = (int)(maxUses * 1.2f);
            uses = maxUses;
        }
    }


}
