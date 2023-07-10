using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string lobby;

   void OnTriggerEnter(Collider col){
       if(col.name == "Body Collider"){
           SceneManager.LoadScene(lobby);
       }
   }
}
