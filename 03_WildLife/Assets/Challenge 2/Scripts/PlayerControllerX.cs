using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeSinceLastFire = 1f; //Tiempo desde el ultimo disparo
    private float fireRate = 1f;  //Cada un segundo permito disparar
    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire +=Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastFire>=fireRate)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeSinceLastFire=0;
        }
    }
}
