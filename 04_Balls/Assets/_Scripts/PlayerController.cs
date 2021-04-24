using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    private GameObject folcalPoint;
    public bool hasPowerUP;
    public float powerUpForce;
    public float powerUpTime=5f;
    public GameObject[] powerUpIndicators;
    void Start()
    {
        _rigidbody=GetComponent<Rigidbody>();
        folcalPoint=GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //Fuerza = masa * aceleracion
        //ForceMode.Force --> tiene en cuenta la masa, es el por defecto
        //ForceMode.Aceleration --> No tiene en cuenta la masa. Siempre envía la misma fuerza sin depender de la masa
        _rigidbody.AddForce(folcalPoint.transform.forward * moveForce * forwardInput,ForceMode.Force);   

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position=transform.position + 0.5f*Vector3.down;
        }  
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUP=true;
            Destroy(other.gameObject);
            StartCoroutine("PowerUpCountDown");
        }
        if (other.gameObject.name.CompareTo("KillZone")==0)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")&&hasPowerUP)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //Para saber la posicion, se resta el destino contra el origen
            //No hace falta normalizar la posicion, ya que siempre será la misma distancia.
            Vector3 awayFromPlayer = collision.gameObject.transform.position-transform.position;
            //Hago una fuerza de impulso para que le de toda la fuerza de una vez.
            enemyRigidbody.AddForce(awayFromPlayer*powerUpForce,ForceMode.Impulse);
        }
    }
    /// <summary>
    /// Corutina, cada varios segundos pone en false el hasPowerUp
    /// </summary>
    /// <returns></returns>
    IEnumerator PowerUpCountDown()
    {
        foreach(GameObject powerUpIndicator in powerUpIndicators)
        {
            powerUpIndicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
            powerUpIndicator.gameObject.SetActive(false);
        }
        hasPowerUP=false;
    }
}
