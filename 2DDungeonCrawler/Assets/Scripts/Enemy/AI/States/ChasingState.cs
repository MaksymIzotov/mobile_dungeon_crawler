using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChasingState", menuName = "States/Chasing State", order = 1)]
public class ChasingState : EnemyBaseState
{
    GameObject player;

    public override void EnterState(EnemyStateManager manager)
    {
        //manager.gameObject.GetComponent<EnemyAnimationController>().Chase();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        //manager.GetComponent<GroundEnemyMovementController>().ChangeDestination();

        //If player is in attack range check
        
    }
}
