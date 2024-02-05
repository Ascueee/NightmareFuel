using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //getter methods


    //Miscelaneous Methods
    public void UpdateTime()
    {
        //currentTime = musicSource.time;
        //timeLastFrame = musicSource.time - currentTime;
        //print(currentTime);
        //print(currentTime);
            
        

    }

}
