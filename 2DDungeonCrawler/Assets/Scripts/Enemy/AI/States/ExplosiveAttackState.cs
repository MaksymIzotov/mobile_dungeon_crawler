using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ExplosiveAttackState", menuName = "States/Explosive Attack State", order = 1)]
public class ExplosiveAttackState : EnemyBaseState
{
    GameObject player;

    public GameObject explosionParticles;

    public override void EnterState(EnemyStateManager manager)
    {
        //Attack and destroy
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHealthController>().TakeDamage(manager.attack.damage);

        //Spawn particles
        Instantiate(explosionParticles, manager.transform.position, Quaternion.identity);
        Destroy(manager.gameObject);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        
    }
}
