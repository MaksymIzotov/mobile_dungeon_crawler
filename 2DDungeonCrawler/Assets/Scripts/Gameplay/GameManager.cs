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

    private int currentDungeon = 1;
    private int totemsLeft;
    public void DungeonCompleted()
    {
        currentDungeon++;
        UpdateDungeonCounter();

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.Find("Dungeon"));
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
        GameSetup.Instance.SpawnPlayer();
        GameManager.instance.SetupTotemsAmount();
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
            Invoke("DungeonCompleted", 2);
        }
    }
}
