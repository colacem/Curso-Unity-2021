using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    private float spawnRate=1f;
    public TextMeshProUGUI scoreText;
    private int _score;
    private int Score
     {
         set{
            //_score = Mathf.Max(value,0 ); // para que no baje de 0
            _score = Mathf.Clamp(value,0,9999); // para que vaya desde 0 a 9999
         }
         get{
             return _score; 
         }
     }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = Random.Range(0,targetPrefabs.Count);
            Instantiate(targetPrefabs[idx]);
        }
        
    }
    /// <summary>
    /// Recibe una puntuacion y actualiza el score en pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación</param>
    public void UpdateScore (int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: \n" + Score;
    }
}
