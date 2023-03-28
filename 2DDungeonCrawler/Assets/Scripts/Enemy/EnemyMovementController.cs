using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject player;

    private Vector2 lastPos;

    [SerializeField] private bool isReverse;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isReverse)
        {
            if (transform.position.x - player.transform.position.x <= 0)
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            if (transform.position.x - player.transform.position.x >= 0)
                GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (transform.position.x - player.transform.position.x <= 0)
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            if (transform.position.x - player.transform.position.x >= 0)
                GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }

    private void LateUpdate()
    {
        lastPos = transform.position;
    }

    public void ChangeDestination()
    {
        GetComponent<AIDestinationSetter>().target = player.transform;
    }

    public void StopAgent()
    {
        GetComponent<AIDestinationSetter>().target = transform;
    }

    public void IsPlayerNear()
    {
        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().AttackingState);
        StopAgent();
    }
}