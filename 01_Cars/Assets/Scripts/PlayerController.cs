using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{   
    [Range(0,20), SerializeField , Tooltip("Velocidad máxima lineal del vehiculo")]
    private float speed = 5.0f;
    [Range(0,10), SerializeField, Tooltip("Velocidad máxima de giro del vehiculo")]
    private float turnSpeed=45f;
    private float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
     //Debug.Log("Mesaje de Consola del "+gameObject.name );   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput  = Input.GetAxis("Vertical");

        transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput );
        transform.Rotate(turnSpeed*Time.deltaTime*Vector3.up*horizontalInput);
        //20 metros por el delay entre frame  hacia adelante
        //velocidad * tiempo * direccion
    }
}
