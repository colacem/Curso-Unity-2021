using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DificultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager gameManager;
    [Range(1,3)]
    public int difficulty;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        _button=GetComponent<Button>();
        _button.onClick.AddListener(SetDificulty);
    }

    void SetDificulty()
    {
        //Debug.Log("Boton: " + gameObject.name );
        gameManager.StartGame(difficulty);
    }
}
