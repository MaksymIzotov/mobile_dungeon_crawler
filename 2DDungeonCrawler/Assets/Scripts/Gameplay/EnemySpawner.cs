using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float minDelay = 3;
    [SerializeField] private float maxDelay = 10;

    List<Transform> spawners = new List<Transform>();

    private int enemiesSpawned = 0;

    private void Start()
    {
        Invoke("DelayedStart", 0.2f);
        Invoke("StartSpawning", minDelay);
    }

    private void DelayedStart()
    {
        spawners = GetAllSpawners();
    }

    private void StartSpawning()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (GameManager.instance.GetCanSpawn())
            {
                if (enemiesSpawned <= 7)
                {
                    if (GetAllSpawners().Count > 0)
                    {
                        spawners.Clear();
                        spawners = GetAllSpawners();
                    }

                    GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawners[Random.Range(0, spawners.Count)].position, Quaternion.identity);
                    enemy.GetComponent<EnemyHealthController>().onDeath.AddListener(EnemyKilled);
                    enemiesSpawned++;
                }
            }
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    public void EnemyKilled()
    {
        GameManager.instance.EnemyKilled();
        enemiesSpawned--;
    }

    private List<Transform> GetAllSpawners()
    {
        List<Transform> buffer = new List<Transform>();

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
            return null;

        Transform[] children = GetClosestSpawnPoint(player).parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.CompareTag("EnemySpawner"))
                buffer.Add(child);
        }

        return buffer;
    }

    public Transform GetClosestSpawnPoint(Transform player)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");

        int index = 0;
        float minDist = Vector3.Distance(player.position, spawnPoints[0].transform.position);
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            float dist = Vector3.Distance(player.position, spawnPoints[i].transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                index = i;
            }
        }

        return spawnPoints[index].transform;
    }
}
