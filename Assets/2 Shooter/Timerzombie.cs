using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerzombie : MonoBehaviour
{
    public float timeValue = 0;
    public Text timeText;
    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted){
            timeValue -= Time.deltaTime;            
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
    }

    public void pause(){
        isStarted = false;
    }

    public void reset(){
        isStarted = false;
        timeValue = 0;
    }
}
