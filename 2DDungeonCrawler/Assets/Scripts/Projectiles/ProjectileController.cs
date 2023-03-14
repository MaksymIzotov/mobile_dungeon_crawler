using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform enemy;
    [SerializeField] private GameObject projectileDestroyPrefab;

    [SerializeField] private float speed;

    private float damage;
    private bool isDestroying = false;

    public void SetupDamage(float _damage)
    {
        damage = _damage;
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
            collision.gameObject.GetComponent<EnemyHealthController>().TakeDamage(damage);
            DestroyParticles();
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
