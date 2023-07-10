using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public int numOfObjects = 3;
    public GameObject[] cylinders;
    Vector3 posy;

    private void OnTriggerEnter(Collider col){
        for(int i=0; i<numOfObjects; i++){
           posy = cylinders[i].transform.position;
        if(col.gameObject.name.Contains("Ball")){
            posy.y = 4.5f;
            cylinders[i].transform.position = posy;
        } 
        } 
    }
}
