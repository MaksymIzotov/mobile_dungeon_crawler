using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defence", menuName = "Upgrades/Defence", order = 1)]
public class AddDefence : Upgrade
{
    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Added defence");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>().AddDefence(1);
    }
}
