using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeResume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
