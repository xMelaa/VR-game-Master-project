using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public GameObject blue;
    Vector3 posy;

    private void OnTriggerEnter(Collider col){
        posy = blue.transform.position;
        if(col.gameObject.name.Contains("bullet")){
            posy.y = 4.5f;
            blue.transform.position = posy;
        }
    }
}
