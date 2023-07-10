using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlayer : MonoBehaviour
{

    public GameObject Player;
 
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject == Player){
            Player.transform.parent = transform;
        }
    }

    private void OnCollisonExit(Collision collision){
        if(collision.gameObject == Player){
            Player.transform.parent = null;
        }
    }
}
