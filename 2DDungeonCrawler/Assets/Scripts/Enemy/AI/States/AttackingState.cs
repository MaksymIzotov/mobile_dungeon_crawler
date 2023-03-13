using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "States/Attack State", order = 1)]
public class AttackingState : EnemyBaseState
{
    GameObject player;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.gameObject.GetComponent<EnemyAttackController>().CanAttackSwitch(true);

    }

    public override void UpdateState(EnemyStateManager manager)
    {
        //Attack
    }
}
