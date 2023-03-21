using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DecreaseDelay", menuName = "Upgrades/DecreaseDelay", order = 1)]
public class DecreaseDelay : Upgrade
{
    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Delay between attacks is decreased");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().DecreaseDelay(0.05f);
    }
}
