using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour
{
    public static UpgradesController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Upgrade[] listOfUpgrades;

    private Upgrade[] selectedUpgrades = new Upgrade[3];

    [SerializeField] private GameObject upgradesParent;
    [SerializeField] private Image[] upgradesImages;

    public void GenerateUpgrades()
    {
        upgradesParent.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            selectedUpgrades[i] = listOfUpgrades[Random.Range(0, listOfUpgrades.Length)];
        }

        for (int i = 0; i < upgradesImages.Length; i++)
        {
            upgradesImages[i].sprite = selectedUpgrades[i].icon;
        }

        PauseGame();
    }

    public void PickUpgrade(int index)
    {
        selectedUpgrades[index].UpgradeStats();

        upgradesParent.SetActive(false);

        UnpauseGame();
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}