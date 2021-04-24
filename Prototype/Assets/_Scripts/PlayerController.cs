using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool usePhysicEngine;
    [Range(0,180)]
    public float moveSpeed=10, rotateSpeed=10, force=10;
    private Rigidbody _rigidbody;
    private float verticalInput, horizontalInput;
    public float maxPositioninBound=14f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtener los input de las teclas o mandos
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");

        MovePlayer();

        KeepPlayerinBounds();


    }
    void MovePlayer()
    {
        
        if(usePhysicEngine)
            {
            //Si utilizamos la fisica utilizamos Addforce o AddTorque(Rotate) al Rigidbody
            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * force * verticalInput , ForceMode.Force);
            _rigidbody.AddTorque (Vector3.up * Time.deltaTime * force * horizontalInput , ForceMode.Force);
            Debug.Log("Fisicaoriz:"+usePhysicEngine);
            }
        else 
            {
            //Si no usamos la fisica, movemos con Transform.Traslate o Rotate
            //-> Mueve sin tener en cuenta friccion o fisica.
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * horizontalInput);
            Debug.Log("Horiz:"+usePhysicEngine);
            }
    }

    void KeepPlayerinBounds()
    {
        //TODO: Refactorizar variable el 14
        if (Mathf.Abs(transform.position.x)>=maxPositioninBound || Mathf.Abs(transform.position.z)>=maxPositioninBound)
        {
            _rigidbody.velocity=Vector3.zero;
            if (transform.position.x>maxPositioninBound){transform.position=new Vector3(maxPositioninBound,transform.position.y,transform.position.z);}
            if (transform.position.x<-maxPositioninBound){transform.position=new Vector3(-maxPositioninBound,transform.position.y,transform.position.z);}
            if (transform.position.z>maxPositioninBound){transform.position=new Vector3(transform.position.x,transform.position.y,maxPositioninBound);}
            if (transform.position.z<-maxPositioninBound){transform.position=new Vector3(transform.position.x,transform.position.y,-maxPositioninBound);}
        
        }
    }
}
