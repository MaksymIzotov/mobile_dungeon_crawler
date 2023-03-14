using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private GameObject loading;

    private void Start()
    {
        LoadHighscore();
    }

    private void LoadHighscore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highscoreText.text = "Highest dungeon reached:\n" + PlayerPrefs.GetInt("Highscore");
        else
            highscoreText.text = "Highest dungeon reached:\n" + 1;
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        loading.SetActive(true);
        

        while (!operation.isDone)
        {
            
            yield return null;
        }
    }
}
