using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void Attack()
    {
        animator.Play("Attack");
    }

    public void Die()
    {
        animator.Play("Die");
    }

    public void Chase()
    {
        animator.Play("Chase");
    }
}
