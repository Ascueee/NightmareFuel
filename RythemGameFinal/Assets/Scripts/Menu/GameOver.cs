using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public static bool GameEnded;
    public List<string> _sceneNames;
    public GameObject gameOver;

    void Start()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        GameEnded = false;
        AudioListener.pause = false;
    }
    void Update()
    {
        if (Player.healthTracker < 0)
        {
            {
                Ended();
            }
        }
    }
    void Ended()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        GameEnded = true;
        AudioListener.pause = true;
    }

    public void ExtraPause(string sceneName)
    {
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        GameEnded = false;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);

    }
}