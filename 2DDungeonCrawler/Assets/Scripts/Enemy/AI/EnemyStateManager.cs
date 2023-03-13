using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public EnemyBaseState SpawnState;
    public EnemyBaseState ChasingState;
    public EnemyBaseState AttackingState;
    public EnemyBaseState StunState;

    public GameObject attackPoint;

    private void Start()
    {
        currentState = SpawnState;

        SpawnState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public EnemyBaseState GetCurrentState()
    {
        return currentState;
    }
}
