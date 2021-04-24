using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
        private float speed=1000;

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime (Cantidad de frame x segundo)
        transform.Rotate(Vector3.forward  * speed* Time.deltaTime );
    }
}
