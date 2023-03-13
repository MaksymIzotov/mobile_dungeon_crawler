using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Regen", menuName = "Upgrades/Regen", order = 1)]
public class AddRegen : Upgrade
{
    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Health regeneration upgraded");
        //Do upgrade
    }
}
