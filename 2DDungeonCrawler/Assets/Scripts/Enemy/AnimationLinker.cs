using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationLinker : MonoBehaviour
{
    private void PlayerAttack()
    {
        transform.root.GetComponent<PlayerAttackController>().Attack();
    }

    private void PlayerProjectileSpawn()
    {
        transform.root.GetComponent<PlayerAttackController>().SpawnProjectile();
    }

    private void EnemyAttack()
    {
        transform.root.GetComponent<EnemyAttackController>().DealDamage();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
