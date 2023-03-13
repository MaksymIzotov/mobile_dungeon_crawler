using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup Instance;

    GameObject player;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] cameras;

    void Start()
    {
        Application.targetFrameRate = 144;
    }

    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, GetSpawnPoint().transform.position, Quaternion.identity);

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].GetComponent<CameraFollow>().target = player.transform;
        }
    }

    public void RespawnPlayer()
    {
        player.transform.position = GetSpawnPoint().position;
    }

    public Transform GetSpawnPoint()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}
