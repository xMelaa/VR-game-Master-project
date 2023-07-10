using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerBS : MonoBehaviour
{
    public bool isStarted = false;  
    [SerializeField] AudioSource music;  

    void Start(){
        Time.timeScale = 0f;
        music.Stop();
    }

    public void start(){
        isStarted = true;
        Time.timeScale = 1f;
        music.Play();
    }

    public void reset(){
        Time.timeScale = 0f;
        isStarted = false;
        music.Stop();
        SceneManager.LoadScene(3); //scena 3 - beatsaber
    }    
}
