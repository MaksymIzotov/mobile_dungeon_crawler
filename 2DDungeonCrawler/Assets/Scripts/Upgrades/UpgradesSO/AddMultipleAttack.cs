using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultipleAttack", menuName = "Upgrades/MultipleAttack", order = 1)]
public class AddMultipleAttack : Upgrade
{
    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Your attacks will spawn more projectiles when hitting an enemy");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().SetMultipleAttack(1);
    }
}
