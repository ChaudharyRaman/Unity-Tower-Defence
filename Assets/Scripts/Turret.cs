using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  public Transform target;
  
  
  
  [Header("Attributes")] 
  public float range =15;
  
  
  public float fireRate =1f;
  private float fireCountDown =0f;
  
  [Header("UNITY SETUP FIELD")]
  public float turnSpeed=10;
  public Transform partToRotate;
  public string enemyTag = "Enemy";

  public GameObject bulletPrefab;
  public Transform firePoint;

  private void Start() {
      InvokeRepeating("UpdateTarget",0f,1f);
  }

  void UpdateTarget(){
      GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
      float shortestDistance = Mathf.Infinity;
      GameObject nearestEnemy = null;

      foreach(GameObject enemy in enemies){
          float distanceToenemy = Vector3.Distance(transform.position,enemy.transform.position);
          if( distanceToenemy < shortestDistance){
              shortestDistance = distanceToenemy;
              nearestEnemy = enemy;
          }

          if(nearestEnemy!=null && shortestDistance <= range){
              target = nearestEnemy.transform;
          }else{
              target=null;
          }
      }
  }
  private void Update() {
      if(target==null) return;

        Vector3 dir = target.position -transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0,rotation.y,0);
        if(fireCountDown<=0 ){
            Shoot();
            fireCountDown = 1f/fireRate;
        }
    fireCountDown-=Time.deltaTime;
  }
  void Shoot(){
      Debug.Log("SHoot");
     GameObject bulletGO =  Instantiate(bulletPrefab,firePoint.position,firePoint.rotation) as GameObject; 
     Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet!=null){
            bullet.Seek(target);
        }
  }

  private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position,range);
  }
}
