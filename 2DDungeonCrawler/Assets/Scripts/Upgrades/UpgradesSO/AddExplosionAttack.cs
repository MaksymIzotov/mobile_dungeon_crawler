using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplosiveAttack", menuName = "Upgrades/ExplosiveAttack", order = 1)]
public class AddExplosionAttack : Upgrade
{
    public override void UpgradeStats()
    {
        if(level == 0)
        {
            MessageShow.instance.ShowNotification("Your attacks are explosive now");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().SetIsExplosive(true);
        }
        else
        {
            MessageShow.instance.ShowNotification("Explosion attack radius is upgraded");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>().AddExplosioRadius(0.05f);
        }
    }
}
