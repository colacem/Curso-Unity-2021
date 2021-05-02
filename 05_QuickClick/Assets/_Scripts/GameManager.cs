using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private const string MAX_SCORE = "MAX_SCORE";
    public enum GameState
    {
        loading,inGame,gameOver
    }
    public GameState gameState;
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targetPrefabs;
    private float spawnRate=2f;
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
     public Button restartButtom;
    public GameObject tittleScreen;
    private int numberOfLives=4;
    public List<GameObject> lives;
    private void Start() {
        ShowMaxScore();
    }
    
/// <summary>
/// Funcion para comenzar el juego, cambiando el estado del juego
/// </summary>
/// <param name="difficulty">Numero entero para la dificultad del juego
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        tittleScreen.SetActive(false);
        spawnRate /= difficulty;
        numberOfLives -= difficulty;

        for (int i = 0; i<numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }

        StartCoroutine(SpawnTarget());
        Score=0;
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        while(gameState==GameState.inGame)
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

    public void ShowMaxScore()
    {
        int maxScore=PlayerPrefs.GetInt(MAX_SCORE,0);
        scoreText.text = "Score: \n" + maxScore;
    }

/// <summary>
/// Seteo el maximo score en el dispositivo
/// </summary>
    private void SetMaxScore()
    {
        int maxScore=PlayerPrefs.GetInt(MAX_SCORE);
        if (Score>maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE,Score);
            //TODO: si hay puntuacion maxima, lanzar cohetes.
        }
    }
    /// <summary>
    /// Paso al modo de Game Over
    /// </summary>
    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >= 0)
        {
            //lives[numberOfLives].SetActive(false);
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color=tempColor;
        }
        if (numberOfLives<=0)
        {
            SetMaxScore();
        
            gameState=GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButtom.gameObject.SetActive(true);
        }
}

/// <summary>
/// Reinicio el juego
/// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
