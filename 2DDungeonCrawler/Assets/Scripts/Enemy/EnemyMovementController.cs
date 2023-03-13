using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject player;
    private AIPath aiPath;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
    }

    private void OnEnable()
    {
        aiPath = GetComponent<AIPath>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeDestination()
    {
        aiPath.destination = player.transform.position;
    }

    public void StopAgent()
    {
        aiPath.destination = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().AttackingState);
        StopAgent();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().ChasingState);
    }
}