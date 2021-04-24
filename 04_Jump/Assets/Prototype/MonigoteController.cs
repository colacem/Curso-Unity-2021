using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonigoteController : MonoBehaviour
{
    private Animator _animator;
    private const string MOVE_HANDS = "Move Hands";
    private const string MOVE = "Is Moving";
    
    private const string MOVE_X = "Move_X";
    
    private const string MOVE_Y = "Move_Y";
    private bool isMovingHands=false;
    private float moveX=0f, moveY=0f;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HANDS,false);
        _animator.SetBool(MOVE,false);
               
    }

    // Update is called once per frame
    void Update()
    {
        moveX=Input.GetAxis("Horizontal");
        moveY=Input.GetAxis("Vertical");

        //Teorema pitagoras para saber si alguno tiene valor
        if (Mathf.Sqrt(moveX*moveX + moveY*moveY)>0.01)
        {
            _animator.SetFloat(MOVE_X,moveX);
            
            _animator.SetFloat(MOVE_Y,moveY);
            _animator.SetBool(MOVE,true);
        }
        else
        {   _animator.SetBool(MOVE,false);}

       if (Input.GetKeyDown(KeyCode.Space ))
       {
           isMovingHands=!isMovingHands; //Cambio el valor al bool
            _animator.SetBool(MOVE_HANDS,isMovingHands );
       } 
    }
}
