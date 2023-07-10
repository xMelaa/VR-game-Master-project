using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 0;
    public Text timeText;
    public bool isStarted = false;
    public GameObject wall;

    void Update(){
        if(isStarted){
            timeValue += Time.deltaTime;            
        }
        DisplayTime(timeValue);  
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0) timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 *100;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }

    public void start(){
        isStarted = true;
        Destroy(wall);
    }

    public void pause(){
        isStarted = false;
    }

    public void reset(){
        isStarted = false;
        timeValue = 0;
    }
}
