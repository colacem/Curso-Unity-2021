using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    //private Vector3 playerPreviusPosition = Vector3.zero;
    //private float distance = 20f;
//private Vector3 offset = new Vector3(0,10,-10);
private Vector3 offset = new Vector3(40,0,0);
private Vector3 offsetRotation = new Vector3(0,-80,0);


    // Start is called before the first frame update
    void Start()
    {
      this.transform.Rotate(offsetRotation);
    }

    // Update is called once per frame
    void Update()
    {
      //Vector3 offset = plane.transform.position - playerPreviusPosition;
      //if(offset.magnitude < 0.5f){return;}
      //offset.Normalize(); //normalizo a entero
      //transform.position = plane.transform.position - offset * distance;
      //transform.LookAt(plane.transform.position);
      //playerPreviusPosition = plane.transform.position;

      this.transform.position = plane.transform.position + offset;
      
    }
}
