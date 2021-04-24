using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float spawnRange=9;
    private int enemyCount;
    public int enemyWave=1;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }
    void Update() {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            enemyWave ++;
            SpawnEnemyWave(enemyWave);
            Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);
        }
    }
//TODO: Alguien implemente esto
/// <summary>
/// Genera una posicion aleatoria dentro de la zona de juego
/// </summary>
/// <returns>Devuelve una posicion aleatoria dentro de la zona de juego</returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        return new Vector3(spawnPosX,0,spawnPosZ);
    }

    /// <summary>
    /// Genera una oleada de Enemigos
    /// <param name="numberOfEnemies">Numero de enemigos a crear</param>
    /// </summary>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i=0; i<numberOfEnemies; i++)
        {
            Instantiate(enemyPrefabs,GenerateSpawnPosition(),enemyPrefabs.transform.rotation );
        }
    }
    
}
