using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointButton1;
    public GameObject checkpointButton2;
    public GameObject checkpointButton3;
    public GameObject player;
    public Transform tp;

    public bool checkpoint1 = false;
    public bool checkpoint2 = false;
    public bool checkpoint3 = false;
   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){

    }

    IEnumerator Teleport(){
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(
            tp.transform.position.x,
            tp.transform.position.y,
            tp.transform.position.z            
        );
    }
}
