using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    //public EnemyAttack properties;

    public bool isAttacking = false;
    public bool canAttack = false;

    [SerializeField] private float delay;

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
        if (isPlayerNear)
        {
            Debug.Log("Dealing damage");
        }

        yield return new WaitForSeconds(delay);

        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        isPlayerNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }

        isPlayerNear = false;
    }
}
