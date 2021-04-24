using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound=30f;
    
    private float lowerBound=-15f;
    
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z>topBound)
        {
            Destroy(this.gameObject);
        }
        else if (this.transform.position.z<lowerBound )
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);

            // paralizo el tiempo de pasar de frame. Freno el juego.
            Time.timeScale=0;
        }
    }
}
