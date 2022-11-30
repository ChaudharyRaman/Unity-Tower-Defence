using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float speed = 10;
    private Transform target;
    private int wavePointIndex = 0;

    private void Start() {
        target = WavePoints.points[0];
    }
    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime , Space.World);

        if(Vector3.Distance(target.position,transform.position)<=0.4f){
            GetNextWavePoint();
        }
    }
    void GetNextWavePoint(){
        if(wavePointIndex>=WavePoints.points.Length -1){
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WavePoints.points[wavePointIndex];
    }
}
