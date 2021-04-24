using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;
    private float horizontalInput;

        // Update is called once per frame
    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up* horizontalInput * rotateSpeed* Time.deltaTime);    
    }
}
