using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
   
    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    
    private float count=0f;
    private float nextWaitTime=5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    /*private void Update() {
        //Instancio cada bola en tiempo aleatorio
        count += Time.deltaTime;
        if (count >= nextWaitTime)
        {
            //Debug.LogFormat("Se instanció un objeto a los {0} segundos",nextWaitTime );
           Invoke("SpawnRandomBall",startDelay);
            count=0;
           nextWaitTime=Random.Range(2,5);
        }
        
    }
    */
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int ballIndex = Random.Range(0,ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        startDelay=Random.Range(1f,5f);
        Invoke("SpawnRandomBall",startDelay);
    }

}
