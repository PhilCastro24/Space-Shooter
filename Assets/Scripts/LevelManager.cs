using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(LoadDelay("Level 1",sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadDelay("Game Over", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator LoadDelay(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
