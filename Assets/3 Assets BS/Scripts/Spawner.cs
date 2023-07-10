using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60/130)*2;
    public float timer;
    public float timeValue = 30; //czas muzyki

    void Update()
    {
        if(timer>beat && timeValue>0){
            GameObject cube = Instantiate(cubes[Random.Range(0,2)], points[Random.Range(0,9)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90*Random.Range(0,4));
            timer -= beat;
            Destroy(cube, 30);            
        }
        timeValue -= Time.deltaTime;
        timer += Time.deltaTime;

        if(timeValue<0) timeValue =0;       
    }
}
