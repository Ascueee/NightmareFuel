using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] private float delay;
    
    private float timeTotal;
    public static bool resultShown;
    public List<string> _sceneNames;
    public GameObject resultMenu;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    void Start()
    {
        resultMenu.SetActive(false);
        D.SetActive(false);

    }
    void Update()
    {
        timeTotal += Time.deltaTime;

        if (timeTotal > delay)
        {
            Pause();
        }
    }
    void Pause()
    {
        resultMenu.SetActive(true);
        Time.timeScale = 0f;
        resultShown = true;
        AudioListener.pause = true;

        if (Player.scoreTracker == 0)
        {

            D.SetActive(true);
        }
    }

    public void Resume()
    {
        resultMenu.SetActive(false);
        Time.timeScale = 1f;
        resultShown = false;
        AudioListener.pause = false;
    }

    public void ExtraPause(string sceneName)
    {
        resultMenu.SetActive(false);
        Time.timeScale = 1f;
        resultShown = false;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);

    }
}
