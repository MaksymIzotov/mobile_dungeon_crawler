using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimationLinker : MonoBehaviour
{
    private void Attack()
    {
        transform.parent.GetComponent<EnemyAttackController>().DealDamage();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
