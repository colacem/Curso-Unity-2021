using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float fuerzaMinima=12, fuerzaMaxima=16, torqueValor=10, positionX=4, positionY=-5;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position= RandomSpamPos();
    }

    void Update()
    {
        //TODO HACE ESTO
    }

    /// <summary>
    /// Devuelve un vector3 random entre FuerzaMinima y FuerzaMaxima
    /// </summary>
    /// <returns></returns>
    private Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(fuerzaMinima,fuerzaMaxima);
    }

    /// <summary>
    /// Devuelve un float random entre -torqueValor y torqueValor
    /// </summary>
    /// <returns></returns>
    private float RandomTorque()
    {
        return Random.Range(-torqueValor,torqueValor);
    }

    /// <summary>
    /// Devuelve un vector aleatorio para posicionar el spam de objetos con z=0
    /// </summary>
    /// <returns></returns>
    private Vector3 RandomSpamPos()
    {
        return new Vector3(Random.Range(-positionX,positionX),positionY,1);
    }

    private void OnMouseDown() {
        Destroy(gameObject);
    }

    /// <summary>
    /// Destruyo los gameobject que traspazan el killzone de debajo de escena
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
