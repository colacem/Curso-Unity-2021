using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   
    public GameObject[] enemies; 
    public float spanRangex=14f;
    private float spawnPosZ;
    private  int animalIndex;
    [SerializeField, Range(2,5)]
    private float startDelay=2f;
    [SerializeField,Range(0.1f,3f)]
    private  float spawnInterval=1.5f;
    private void Start() {
        //Uso transform.position.z para ponerlo en la misma posicion del spawn manager
        //Cacheo la variable para gastar menos recursos
        spawnPosZ=this.transform.position.z;

        InvokeRepeating("SpawnRandomEnemy",startDelay,spawnInterval);
    }
    
    
     private void SpawnRandomEnemy()
    {
        float xRand =Random.Range(-spanRangex,spanRangex);
        Vector3 spawnPos = new Vector3(xRand,0,spawnPosZ);

        animalIndex = Random.Range(0,enemies.Length );
                
        Instantiate(enemies[animalIndex]
                   ,spawnPos
                   ,enemies[animalIndex].transform.rotation);
    }
}
