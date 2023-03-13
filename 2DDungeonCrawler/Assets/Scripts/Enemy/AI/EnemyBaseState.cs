using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : ScriptableObject
{
    public virtual void EnterState(EnemyStateManager manager) { }

    public virtual void UpdateState(EnemyStateManager manager) { }
}
