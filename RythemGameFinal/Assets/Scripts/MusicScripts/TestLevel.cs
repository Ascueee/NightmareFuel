using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioClip music;

    [Header("Timer Data")]
    [SerializeField] float currentTime;
    [SerializeField] float timeLastFrame;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timeLastFrame = 0;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCalculation();
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    void TimeCalculation()
    {
        currentTime = musicSource.time - timeLastFrame;
        timeLastFrame = musicSource.time;
        
    }
}
