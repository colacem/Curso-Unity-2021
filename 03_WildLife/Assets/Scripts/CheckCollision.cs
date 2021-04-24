using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // onTriggerEnter se ejecuta cada vez que un objeto entre en el trigger del gamobject que tiene este script
    private void OnTriggerEnter(Collider other) {
        //solo lo ejecuto cuando las balas chocan con los animales que tienen el tag enemies
        if (other.CompareTag("enemies")){
            Destroy(this.gameObject); //Destruye el objeto que tiene el script
            Destroy(other.gameObject); //Destruye el objeto que entro en el trigger
        }
    }
}
