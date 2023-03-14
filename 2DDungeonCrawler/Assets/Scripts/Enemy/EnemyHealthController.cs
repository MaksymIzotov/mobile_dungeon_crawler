using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthController : MonoBehaviour
{
    public Health properties;

    private float maxhp;
    private float hp;
    private float lastHp;
    private float defence;
    private float hpRegen;

    private bool isDead;

    public UnityEvent onDeath;

    private void Awake()
    {
        SetValues();
    }

    private void Update()
    {
        HealthRegen();
    }

    private void LateUpdate()
    {
        if (lastHp != hp)
        {
            GetComponent<EnemyHealthbar>().UpdateHealthbarValue(maxhp, hp);
        }

        lastHp = hp;
    }

    public void HealthRegen()
    {
        if (hp >= maxhp) { return; }

        hp += hpRegen * Time.deltaTime;

    }


    public void TakeDamage(float damage)
    {

        float actualDamage = damage - (damage / 100 * defence);
        hp -= actualDamage;

        if (hp <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        hp += amount;

        if (hp >= maxhp)
            hp = maxhp;
    }

    public void Die()
    {
        if (isDead) { return; }

        GetComponent<EnemyAnimationController>().Die();
        GetComponent<EnemyMovementController>().StopAgent();
        onDeath.Invoke();
        isDead = true;
    }

    private void SetValues()
    {
        //Add mult
        maxhp = properties.healthPoints;
        hp = maxhp;
        defence = properties.defence;
        hpRegen = properties.healthRegen;
        isDead = false;
    }
}
