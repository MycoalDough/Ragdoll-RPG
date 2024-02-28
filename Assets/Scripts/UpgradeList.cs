using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeList
{
    public string name;
    public string description;
    public int cost;
    public int indexNumber;
    public bool bought;
    //public Image image;
    
    public UpgradeList(string Name, string Description, int Cost, int Number, bool Bought)//, Image newImage)
    {
        name = Name;
        description = Description;
        cost = Cost;
        indexNumber = Number;
        bought = Bought;
        //image = newImage;

    }
}
