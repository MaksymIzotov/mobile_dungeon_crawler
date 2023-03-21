using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public Attack properties;

    public bool isAttacking = false;
    public bool canAttack = false;

    private bool isPlayerNear = false;

    private void Update()
    {
        if (!canAttack) { return; }
        if (isAttacking) { return; }

        if (!isPlayerNear)
        {
            canAttack = false;
            GetComponent<EnemyStateManager>().SwitchState(GetComponent<EnemyStateManager>().ChasingState);
            return;
        }

        isAttacking = true;
        GetComponent<EnemyAnimationController>().Attack();
        Attack();
    }

    public void CanAttackSwitch(bool _canAttack)
    {
        canAttack = _canAttack;
    }

    public void Attack()
    {
        StartCoroutine("PerformAttack");
    }

    IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(properties.delay);

        isAttacking = false;
    }

    public void DealDamage()
    {
        if (isPlayerNear)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>().TakeDamage(properties.damage * GameManager.instance.difficulty.enemyDamageMult); //Add multipliers
        }
    }

    public void SetIsPLayerNear(bool value)
    {
        isPlayerNear = value;
    }
}
