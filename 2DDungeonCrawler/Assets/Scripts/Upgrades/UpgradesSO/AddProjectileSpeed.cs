using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpeed", menuName = "Upgrades/ProjectileSpeed", order = 1)]
public class AddProjectileSpeed : Upgrade
{
    public override void UpgradeStats()
    {
        MessageShow.instance.ShowNotification("Attack projectile speed is upgraded");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().AddProjectileSpeed(0.05f);
    }
}
