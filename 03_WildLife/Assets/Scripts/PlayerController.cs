using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput,verticalInput;
    public float speed=10f;
    public float xRange=15f;
    public Vector2 yRange=new Vector2(15,-1);
    public GameObject proyectilePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);

        if(transform.position.x<-xRange )
        {
            transform.position=new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        else if(transform.position.x>xRange )
        {
            transform.position= new Vector3(xRange ,transform.position.y,transform.position.z);
        }
        if(transform.position.z<yRange.y)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,yRange.y);
        }
        else if(transform.position.z>yRange.x)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,yRange.x);
        }

        //Lanzamiento de objetos
        if(Input.GetKeyDown (KeyCode.Space))
        {
            //Si presiona la barra espaciadora, dispara el objeto
            Instantiate(proyectilePrefabs,transform.position,proyectilePrefabs.transform.rotation );
        }

   }
}
