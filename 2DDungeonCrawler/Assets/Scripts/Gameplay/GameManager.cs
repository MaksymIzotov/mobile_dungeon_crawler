using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text dungeonCounter;
    [SerializeField] private Image loseBackground;
    [SerializeField] private Image transitionBackground;
    [SerializeField] private GameObject loseText;

    GameObject player;

    private bool canSpawn = true;

    private int currentDungeon = 1;
    private int totemsLeft;
    public void DungeonCompleted()
    {
        currentDungeon++;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            if (PlayerPrefs.GetInt("Highscore") < currentDungeon)
                PlayerPrefs.SetInt("Highscore", currentDungeon);
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", currentDungeon);
        }            
        
        UpdateDungeonCounter();

        Destroy(GameObject.Find("Dungeon"));
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-3, -3);
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
        GameSetup.Instance.RespawnPlayer();
        GameManager.instance.SetupTotemsAmount();


        transitionBackground.color = new Color(transitionBackground.color.r, transitionBackground.color.g, transitionBackground.color.b, 0);

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
            StartCoroutine(TransitionFade());

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(9999);
                Destroy(enemy, 2);
            }

            Invoke("DungeonCompleted", 2);
        }
    }

    public void GameOver()
    {
        loseBackground.gameObject.SetActive(true);
        StartCoroutine(LoseFade());
    }

    IEnumerator LoseFade()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            loseBackground.color = new Color(loseBackground.color.r, loseBackground.color.g, loseBackground.color.b, i);
            yield return null;
        }

        loseBackground.color = new Color(loseBackground.color.r, loseBackground.color.g, loseBackground.color.b, 255);
        loseText.SetActive(true);
        loseText.GetComponent<TMP_Text>().text = "Dungeon reached: " + currentDungeon;

        Time.timeScale = 0;
    }

    IEnumerator TransitionFade()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            transitionBackground.color = new Color(transitionBackground.color.r, transitionBackground.color.g, transitionBackground.color.b, i);
            yield return null;
        }

        transitionBackground.color = new Color(transitionBackground.color.r, transitionBackground.color.g, transitionBackground.color.b, 255);
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public bool GetCanSpawn()
    {
        return canSpawn;
    }
}
