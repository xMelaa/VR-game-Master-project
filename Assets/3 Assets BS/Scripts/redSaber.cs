using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class redSaber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public ParticleSystem destroyParticles;

    public int point = 0;
    public AudioClip sliceSound;

    public float volume;
    //public TextMeshProUGUI textPoints;
   
    void Update(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 4, layer)){
            if(Vector3.Angle(transform.position-previousPos, hit.transform.up)>130){
                Instantiate(destroyParticles.gameObject, transform.position, transform.rotation);
                Destroy(hit.transform.gameObject);
                Vector3 colPosition = hit.transform.position;
                
                AudioSource.PlayClipAtPoint(sliceSound, colPosition, volume);

                point++;
                //textPoints.text = point.ToString();
            }
        }
        previousPos = transform.position;
    }
}
