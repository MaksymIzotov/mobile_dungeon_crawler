using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private Attack properties;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private Animator[] animationSprites;

    private bool canAttack = true;
    private bool isExplosive = false;

    private int attacksAmount = 0;

    [SerializeField] private float projectileSpeed;

    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        properties.damage = properties.base_damage;
        properties.delay = properties.base_delay;
        properties.explosionRadius = properties.base_explosionRadius;
    }

    public void AddDamage(float _damage)
    {
        properties.damage += _damage;
    }

    public void DecreaseDelay(float _delay)
    {
        properties.delay -= _delay;
    }

    public void SetIsExplosive(bool value)
    {
        isExplosive = value;
    }

    public void AddExplosioRadius(float value)
    {
        properties.explosionRadius += value;
    }

    public void SetMultipleAttack(int amount)
    {
        attacksAmount += amount;
    }

    public void AddProjectileSpeed(float value)
    {
        projectileSpeed += value;
    }

    public void Attack()
    {
        StartCoroutine(AttackEnemy());
    }

    IEnumerator AttackEnemy()
    {
        canAttack = false;

        yield return new WaitForSeconds(properties.delay);

        canAttack = true;
        if (enemies.Count > 0)
        {
            for (int i = 0; i < animationSprites.Length; i++)
            {
                animationSprites[i].SetBool("isEnemyNear", true);
            }
        } 
    }

    public void SpawnProjectile()
    {
        for (int i = 0; i < animationSprites.Length; i++)
        {
            animationSprites[i].SetBool("isEnemyNear", false);
        }

        GameObject projectile = Instantiate(projectilePrefab, projectileParent);
        projectile.transform.parent = null;
        projectile.GetComponent<ProjectileController>().SetupDamage(properties.damage, projectileSpeed, isExplosive, properties.explosionRadius);
        projectile.GetComponent<ProjectileController>().SetupMultipleAttacks(attacksAmount);
    }

    public void ChangeEnemiesList(GameObject enemy, bool isAdd)
    {
        if(isAdd)
        {
            enemies.Add(enemy);

            if (!canAttack) { return; }

            if (enemies.Count > 0)
            {
                for (int i = 0; i < animationSprites.Length; i++)
                {
                    animationSprites[i].SetBool("isEnemyNear", true);
                }
            }
        }
        else
        {
            enemies.Remove(enemy);

            if (!canAttack) { return; }

            if (enemies.Count <= 0)
            {
                for (int i = 0; i < animationSprites.Length; i++)
                {
                    animationSprites[i].SetBool("isEnemyNear", false);
                }
            }
        }
    }
}
