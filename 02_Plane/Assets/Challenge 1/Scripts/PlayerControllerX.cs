using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    private float rotationSpeed=100;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Jump");


        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime  * speed *15);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        // tilt the plane right/left 
        transform.Rotate(Vector3.forward   * rotationSpeed * Time.deltaTime * horizontalInput );
    }
}
