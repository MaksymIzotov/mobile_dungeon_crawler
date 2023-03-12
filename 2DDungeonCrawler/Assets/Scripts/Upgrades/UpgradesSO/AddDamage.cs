using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Damage", order = 1)]
public class AddDamage : Upgrade
{
    public override void UpgradeStats()
    {
        Debug.Log("Upgrading damage");
    }
}
