using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    [SerializeField] private List<Upgrade> listOfUpgrades = new List<Upgrade>();
    private List<Upgrade> availableUpgrades = new List<Upgrade>();

    private Upgrade[] selectedUpgrades = new Upgrade[3];

    [SerializeField] private GameObject upgradesParent;
    [SerializeField] private Image[] upgradesImages;

    private void Start()
    {
        ResetUpgrades();
        SetupUpgrades();
    }

    private void SetupUpgrades()
    {
        availableUpgrades = listOfUpgrades;
    }

    public void GenerateUpgrades()
    {
        upgradesParent.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            selectedUpgrades[i] = listOfUpgrades[Random.Range(0, listOfUpgrades.Count)];
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
        selectedUpgrades[index].level++;

        if (selectedUpgrades[index].level >= selectedUpgrades[index].maxLevel)
        {
            //Delete from list
            availableUpgrades.Remove(selectedUpgrades[index]);
        }

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

    private void ResetUpgrades()
    {
        foreach (Upgrade upgrade in listOfUpgrades) {
            upgrade.level = 0;
        }
    }
}
