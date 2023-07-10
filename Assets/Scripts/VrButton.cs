using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool _deadTimeActive = false;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Button" && !_deadTimeActive){
            onPressed?.Invoke();
            Debug.Log("Button Pressed");
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Button" && !_deadTimeActive){
            onReleased?.Invoke();
            Debug.Log("Button Released");
        }
    }

    IEnumerator WaitForDeadTime(){
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
