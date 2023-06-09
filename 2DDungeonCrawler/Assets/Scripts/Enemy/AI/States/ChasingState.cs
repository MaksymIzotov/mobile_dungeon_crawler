using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChasingState", menuName = "States/Chasing State", order = 1)]
public class ChasingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.gameObject.GetComponent<EnemyAnimationController>().Chase();
        manager.GetComponent<EnemyMovementController>().ChangeDestination();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        

        //If player is in attack range check
        
    }
}
