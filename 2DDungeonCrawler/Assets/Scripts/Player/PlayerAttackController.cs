using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private Attack properties;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private GameObject[] animationSprites;

    private bool canAttack = true;

    private List<GameObject> enemies = new List<GameObject>();

    public void Attack()
    {
        StartCoroutine(AttackEnemy());
    }

    IEnumerator AttackEnemy()
    {
        canAttack = false;

        yield return new WaitForSeconds(properties.delay);

        if (enemies.Count > 0)
        {
            for (int i = 0; i < animationSprites.Length; i++)
            {
                animationSprites[i].GetComponent<Animator>().SetBool("isEnemyNear", true);
            }
        }
        canAttack = true;
    }

    public void SpawnProjectile()
    {
        for (int i = 0; i < animationSprites.Length; i++)
        {
            animationSprites[i].GetComponent<Animator>().SetBool("isEnemyNear", false);
        }

        GameObject projectile = Instantiate(projectilePrefab, projectileParent);
        projectile.transform.parent = null;

        //Set damage
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
                    animationSprites[i].GetComponent<Animator>().SetBool("isEnemyNear", true);
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
                    animationSprites[i].GetComponent<Animator>().SetBool("isEnemyNear", false);
                }
            }
        }
    }
}
