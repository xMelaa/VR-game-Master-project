using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class zombieSpawner : MonoBehaviour
{
    public float spawnTime = 2;
    public GameObject spawnGameObject;

    public EnemyController enemyController;
    public Transform[] spawnPoints;
    private float timer; //czas spawnu kolejnego
    public float maxZombie = 0;
    public float maxTime = 60; //sekundy
    private float timeInit; //trzymanie wartosci
    public TextMeshProUGUI textScore;
    public int score = 0;

    public Text timeText;
    public bool isStarted = false;
   
    void Start(){
        //enemyController = GetComponent<EnemyController>();
        timeInit = maxTime;
    }

    public void Update(){
        textScore.text = score.ToString();

        if(isStarted){
            if (timer>spawnTime && maxZombie<20 && maxTime>0){
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
                timer=0;
                maxZombie++;
            } 
       
            timer += Time.deltaTime;
            maxTime -= Time.deltaTime;

            if (maxTime < 0) maxTime = 0;  
        }
        DisplayTime(maxTime);             
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
        maxTime = timeInit;
    }
}
