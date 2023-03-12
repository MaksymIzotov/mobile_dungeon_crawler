using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HP", menuName = "Upgrades/HP", order = 1)]
public class AddHP : Upgrade
{
    public override void UpgradeStats()
    {
        Debug.Log("Upgrading hp");
    }
}
