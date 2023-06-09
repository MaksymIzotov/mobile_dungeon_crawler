using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform enemy;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject projectileDestroyPrefab;

    private float speed;

    private float damage;
    private bool isDestroying = false;
    private bool isExplosive = false;
    private float explosionRadius;

    private int multipleAttackAmount;

    public void SetupDamage(float _damage, float _speed, bool _isExplosive, float _explosionRadius)
    {
        damage = _damage;
        isExplosive = _isExplosive;
        explosionRadius = _explosionRadius;
        speed = _speed;
    }

    public void SetupMultipleAttacks(int _amount)
    {
        multipleAttackAmount = _amount;
    }

    private void Update()
    {
        if (enemy == null)
            enemy = FindClosestEnemy();

        if (isDestroying) { return; }

        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, enemy.position, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isExplosive)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explosionRadius);
                foreach(Collider2D col in colliders)
                {
                    if (col.CompareTag("Enemy"))
                    {
                        DealDamage(col.gameObject);
                    }
                }
            }
            else
            {
                DealDamage(collision.gameObject);
            }
            DestroyParticles();
        }
    }

    private void DealDamage(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealthController>().TakeDamage(damage);

        if(multipleAttackAmount > 0)
        {
            Vector3 spawnPos = enemy.transform.position + Random.insideUnitSphere;
            spawnPos.z = 0;
            GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

            projectile.GetComponent<ProjectileController>().SetupDamage(damage, speed, isExplosive, explosionRadius);
            projectile.GetComponent<ProjectileController>().SetupMultipleAttacks(multipleAttackAmount - 1);
        }
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length == 0)
        {
            DestroyParticles();
            return null;
        }

        int index = 0;
        float minDist = Vector3.Distance(transform.position, enemies[0].transform.position);
        for (int i = 1; i < enemies.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, enemies[i].transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                index = i;
            }
        }

        return enemies[index].transform;
    }

    private void DestroyParticles()
    {
        if (isDestroying) { return; }

        isDestroying = true;
        GetComponent<ParticleSystem>().Stop();
        GetComponent<CircleCollider2D>().enabled = false;
        Instantiate(projectileDestroyPrefab, transform);
        Destroy(gameObject, 2);
    }
}
