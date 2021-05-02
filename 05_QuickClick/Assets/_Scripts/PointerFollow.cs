using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{
    public Camera _camera;
    
    // Update is called once per frame
    void Update()
    {
        //Obtengo la posicion en pantalla del mouse y la convierto a la posicion 3d para poner el rastro.
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x,mousePosition.y,1);
        transform.position=mousePosition;
        
    }
}
