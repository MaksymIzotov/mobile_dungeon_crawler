using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text dungeonCounter;

    GameObject player;

    private bool canSpawn = true;

    private int currentDungeon = 1;
    private int totemsLeft;
    public void DungeonCompleted()
    {
        currentDungeon++;
        PlayerPrefs.SetInt("Highscore", currentDungeon);
        
        UpdateDungeonCounter();

        Destroy(GameObject.Find("Dungeon"));
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        Generator2D.Instance.IncreaseSize();

        Invoke("GenerateDungeon", 0.1f);
        Invoke("PlayerProceed", 0.15f);
    }

    private void GenerateDungeon()
    {
        Generator2D.Instance.Generate();
    }

    private void PlayerProceed()
    {
        Generator2D.Instance.BuildNavMesh();
        player.SetActive(true);
        GameSetup.Instance.RespawnPlayer();
        GameManager.instance.SetupTotemsAmount();

        canSpawn = true;
    }

    private void UpdateDungeonCounter()
    {
        dungeonCounter.text = currentDungeon.ToString();
    }

    public void SetupTotemsAmount()
    {
        totemsLeft = GameObject.FindGameObjectsWithTag("Totem").Length;
    }

    public void ActivateTotem()
    {
        totemsLeft--;

        if (totemsLeft <= 0)
        {
            MessageShow.instance.ShowNotification("All totems are activated");
            canSpawn = false;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(9999);
                Destroy(enemy, 2);
            }

            Invoke("DungeonCompleted", 2);
        }
    }

    public bool GetCanSpawn()
    {
        return canSpawn;
    }
}
