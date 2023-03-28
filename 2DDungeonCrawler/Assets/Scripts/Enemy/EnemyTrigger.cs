using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        transform.root.GetComponent<EnemyAttackController>()?.SetIsPLayerNear(true);
        transform.root.GetComponent<EnemyMovementController>().IsPlayerNear();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        transform.root.GetComponent<EnemyAttackController>()?.SetIsPLayerNear(false);
    }
}
