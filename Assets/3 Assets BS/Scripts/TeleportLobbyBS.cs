using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLobbyBS : MonoBehaviour
{
    public string lobby;
    
    public void LoadLobby(){
        SceneManager.LoadScene(lobby);
    }
}
