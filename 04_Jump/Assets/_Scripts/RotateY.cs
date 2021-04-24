using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float rotateSpeed=60f;
    public float traslateSpeed=10f;
    
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * traslateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up  * rotateSpeed * Time.deltaTime );
    }
}
