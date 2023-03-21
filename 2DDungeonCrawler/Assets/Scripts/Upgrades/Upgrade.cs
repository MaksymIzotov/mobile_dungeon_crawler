using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    [Header("Info")]
    public string upgradeName;
    public Sprite icon;

    [Space(10)]
    [Header("Level")]

    public int level;
    public int maxLevel;

    public virtual void UpgradeStats()
    {

    }
}
