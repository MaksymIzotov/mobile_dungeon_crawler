using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite icon;

    public virtual void UpgradeStats()
    {

    }
}
