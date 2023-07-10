using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    private float time = 0f;
    private bool spawn = false;
    public AudioSource audioSource;
    public AudioClip shootSound;

    void Start(){
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Firebullet);        
    }

    public void Firebullet(ActivateEventArgs arg){
        GameObject spawnedBullet = Instantiate(bullet);
        spawn = true;
        audioSource.PlayOneShot(shootSound);
        //shootSound.Play();
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;        
        
        Destroy(spawnedBullet, 5);
    }   
}
