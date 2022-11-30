using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText ;
    public float timeBetweenWaves =5;
    private float coundDown = 2f;
    private int waveIndex =0;
    private void Update() {
        if(coundDown<=0){
            StartCoroutine(SpawnWave());
            coundDown = timeBetweenWaves;
        }
        coundDown-=Time.deltaTime;     
        waveCountdownText.text = Mathf.Round(coundDown).ToString();     //Florr cut off all the decimal 
    }
    IEnumerator SpawnWave(){
        //Debug.Log("wave incoming");
        waveIndex++;
        for(int i=0;i<waveIndex;i++){
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
    void SpawnEnemy(){
         Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
