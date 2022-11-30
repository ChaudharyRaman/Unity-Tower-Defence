using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject imapctEffect;
    public float speed = 70;
    public float explosionRadius = 0f;

    public void Seek(Transform _target){
        target = _target;
    }

    private void Update() {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame , Space.World);

        transform.LookAt(target);
    }
    private void HitTarget(){
        
        GameObject effectIns = Instantiate(imapctEffect,transform.position,transform.rotation) as GameObject;
        Destroy(effectIns,5f); 

        if(explosionRadius>0){
            Explode();
        }else{
            Damage(target);
        }

       // Destroy(target.gameObject);
        Destroy(gameObject); 
    }
    void Explode(){
       Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach(Collider collider in colliders){
            if(collider.tag == "Enemy"){
               // Debug.Log(collider.name);
                Damage(collider.transform);
                 
            }
        }
    }
    void Damage(Transform enemy){
      //  Debug.Log(enemy.name);
        Destroy (enemy.gameObject);
    }
     private void OnDrawGizmosSelected() {
         Gizmos.color = Color.red; 
         Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
