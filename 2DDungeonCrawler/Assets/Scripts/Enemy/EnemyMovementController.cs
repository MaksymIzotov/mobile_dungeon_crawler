using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject player;

    private Vector2 lastPos;

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
        if(transform.position.x - player.transform.position.x <= 0)
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        if (transform.position.x - player.transform.position.x >= 0)
            GetComponentInChildren<SpriteRenderer>().flipX = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().AttackingState);
        StopAgent();
    }
}