using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float speed = 4f;
   // public int score = 0;
    public Transform target;
    private Rigidbody rig;
    public bool isZombieDead = false;
    [SerializeField] private Animator animator;
    public zombieSpawner zombieSpawner;
    public ParticleSystem destroyParticles;
    //public TextMeshProUGUI textScore;

    void Start(){        
         rig = GetComponent<Rigidbody>();
        //zombieSpawner = GetComponent<zombieSpawner>();
    }

    void Update(){
        var pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name.Contains("bullet")){
            animator.SetBool("isDead", true);
            speed = 0;            
            
            Destroy(collision.gameObject);
            Destroy(gameObject, 5); 
            
            if(!isZombieDead){
                zombieSpawner.maxZombie = zombieSpawner.maxZombie - 1;
                zombieSpawner.score = zombieSpawner.score + 1;
            }            

            isZombieDead = true; 
            Instantiate(destroyParticles.gameObject, transform.position, transform.rotation);
        }
    }  

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
