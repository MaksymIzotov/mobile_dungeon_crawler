using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "Upgrades/Speed", order = 1)]
public class AddSpeed : Upgrade
{

    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Player speed is upgraded");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControl>().AddSpeed(0.05f);
    }
}
