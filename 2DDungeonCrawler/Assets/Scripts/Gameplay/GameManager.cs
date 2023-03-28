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
    [SerializeField] private TMP_Text enemiesCounter;
    [SerializeField] private TMP_Text totemsCounter;
    [SerializeField] private Image loseBackground;
    [SerializeField] private Image transitionBackground;
    [SerializeField] private GameObject loseText;

    [SerializeField] private int enemiesMin;
    [SerializeField] private int enemiesMax;

    public Difficulty difficulty;

    GameObject player;

    private bool canSpawn = true;

    private int currentDungeon = 1;
    private int totemsLeft;

    private int enemiesLeft = 1;

    private bool totemsDestroyed = false;
    private bool enemiesKilled = false;

    private void Start()
    {
        difficulty.enemyHpMult = 1;
        difficulty.enemyDamageMult = 1;
    }

    private void Update()
    {
        if (enemiesKilled && totemsDestroyed)
            DestroyAllEnemies();
    }

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

        difficulty.enemyHpMult *= 1.25f;
        difficulty.enemyDamageMult *= 1.2f;

        enemiesMin++;
        enemiesMax++;

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
        SetupTotemsAmount();
        SetupEnemiesAmount();


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

        totemsCounter.text = "Totems left: " + totemsLeft;
    }

    public void SetupEnemiesAmount()
    {
        enemiesLeft = Random.Range(enemiesMin, enemiesMax);

        enemiesCounter.text = "Enemies goal: " + enemiesLeft;
    }

    public void ActivateTotem()
    {
        totemsLeft--;
        totemsCounter.text = "Totems left: " + totemsLeft;

        if (totemsLeft <= 0)
        {
            MessageShow.instance.ShowNotification("All totems are activated");
            totemsDestroyed = true;
        }
    }

    public void EnemyKilled()
    {
        if (enemiesLeft <= 0) return;

        enemiesLeft--;
        enemiesCounter.text = "Enemies goal: " + enemiesLeft;

        if (enemiesLeft <= 0)
        {
            MessageShow.instance.ShowNotification("Enemies kill goal is reached");
            enemiesKilled = true;
        }
    }

    private void DestroyAllEnemies()
    {
        totemsDestroyed = false;
        enemiesKilled = false;

        canSpawn = false;
        StartCoroutine(TransitionFade());

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<EnemyHealthController>().TakeDamage(9999);
            Destroy(enemy, 2);
        }

        foreach (GameObject chest in GameObject.FindGameObjectsWithTag("Chest"))
        {
            chest.GetComponent<CircleCollider2D>().enabled = false;
        }

        Invoke("DungeonCompleted", 2);
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
