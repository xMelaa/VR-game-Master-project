using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    public void resetScene(){
        Time.timeScale = 0f;
        SceneManager.LoadScene(3); //scena 3 - beatsaber
    }    
}
