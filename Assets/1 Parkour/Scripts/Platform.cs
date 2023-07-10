using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 2f; //predkosc
    public Transform[] spots; //tablica waypointow
    private int spotIndex; //index waypointu do ktorego idzie
    private float dist;
    
    void Start(){
        spotIndex=0;
        transform.LookAt(spots[spotIndex].position);
    }

    void Update(){
        dist = Vector3.Distance(transform.position, spots[spotIndex].position); //liczenie dystansu miedzy postaci a waypointem
        if(dist < 0.1f){ //jesli odleglosc jest mniejsza nmiz 0.1, dodaj waypoint
           AddIndex();
        }
       Move();
    }

    void Move(){
       transform.Translate(Vector3.forward * speed * Time.deltaTime); //poruszanie sie
    }

   void AddIndex(){ //dodawanie indexu
       spotIndex++;
       if(spotIndex ==spots.Length){ //jesli dojdzie do ostatniego indexu 
           spotIndex=0; //wroc do indexu 0
        }
       transform.LookAt(spots[spotIndex].position);   
    }
}
