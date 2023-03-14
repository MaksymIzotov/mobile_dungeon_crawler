using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public Health properties;

    private float maxhp;
    private float hp;
    private float lastHp;
    private float defence;
    private float hpRegen;

    private bool isDead;

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
        if (lastHp != hp) {
            PlayerUIController.Instance.UpdateHP(hp);
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

        //Do effects
        Camera.main.GetComponent<CameraShake>().EnableShaking(actualDamage / 100);


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

        GetComponent<PlayerMovementControl>().enabled = false;
        GameManager.instance.GameOver();
        isDead = true;
    }

    private void SetValues()
    {
        properties.healthRegen = properties.base_healthRegen;
        properties.defence = properties.base_defence;
        properties.healthPoints = properties.base_healthPoints;

        maxhp = properties.healthPoints;
        hp = maxhp;
        defence = properties.defence;
        hpRegen = properties.healthRegen;
        isDead = false;
    }

    public void AddMaxHP(float _maxhp)
    {
        maxhp += _maxhp;
    }

    public void AddDefence(float _defence)
    {
        defence += _defence;
    }

    public void AddHealtRegen(float _hpRegen)
    {
        hpRegen += _hpRegen;
    }
}
