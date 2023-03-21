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
    [SerializeField] private List<Upgrade> listOfSuperUpgrades = new List<Upgrade>();
    private List<Upgrade> availableUpgrades = new List<Upgrade>();
    private List<Upgrade> availableSuperUpgrades = new List<Upgrade>();

    private Upgrade[] selectedUpgrades = new Upgrade[3];

    [SerializeField] private GameObject upgradesParent;
    [SerializeField] private Image[] upgradesImages;

    private bool isSuper;
    private void Start()
    {
        ResetUpgrades();
        SetupUpgrades();
    }

    private void SetupUpgrades()
    {
        availableUpgrades = listOfUpgrades;
        availableSuperUpgrades = listOfSuperUpgrades;
    }

    public void GenerateUpgrades(bool _isSuper)
    {
        isSuper = _isSuper;

        upgradesParent.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            if (isSuper)
                selectedUpgrades[i] = listOfSuperUpgrades[Random.Range(0, listOfSuperUpgrades.Count)];
            else
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
            if (isSuper)
                availableSuperUpgrades.Remove(selectedUpgrades[index]);
            else
                availableUpgrades.Remove(selectedUpgrades[index]);
        }

        foreach (GameObject totem in GameObject.FindGameObjectsWithTag("Totem"))
        {
            totem.GetComponent<CircleCollider2D>().enabled = true;
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
