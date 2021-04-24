using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//para obligar que el player tenga el rigidbody. Si no lo tiene, lo añade automaticamente al añadir el script
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private const string SPEED_MULTIPLIER = "Speed Multiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATHTYPE_INT="DeathType_int";
    private const string DEATH_B="Death_b";
    private Rigidbody playerRb;
    public float jumpForce=10f;
    public float gravityMultiplier=2f;
    private bool isOnGround=true;
    private bool _gameOver=false;
    public bool GameOver  {get => _gameOver;}
    public float speedMultiplier=1;

    private Animator _animator;
    public ParticleSystem explosion, dirt;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0,1)]
    public float audioSound=1f;

    // Start is called before the first frame update
    void Start()
    {
        //asigno el rigidbody del player a la variable
        playerRb=GetComponent<Rigidbody>();
        //playerRb.AddForce(Vector3.up *1000); // F =m*a (Fuerza=masa * aceleeracion)
        Physics.gravity *= gravityMultiplier; //Cambio los parametros de gravedad
        _animator= GetComponent<Animator>(); //recupero el animator del player
        _animator.SetFloat(SPEED_F, 1); //marco para que empiece a correr
        _audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime/10;
        _animator.SetFloat(SPEED_MULTIPLIER,  speedMultiplier); //incremento la velocidad por el tiempo que corre el juego
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround&&!_gameOver)
        {
            playerRb.AddForce(Vector3.up *jumpForce,ForceMode.Impulse); // F =m*a (Fuerza=masa * aceleeracion)
            isOnGround=false;
            _animator.SetTrigger(JUMP_TRIG); //Activo el triger para que anime el salto
            dirt.Stop();

            _audioSource.PlayOneShot(jumpSound,audioSound);
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        //cuando colisiona solo con el suelo marco para que pueda volver a saltar, si colisiona con otra cosa no
        if (other.gameObject.CompareTag("Ground")&&!_gameOver)
        {
            isOnGround=true;
            dirt.Play();
        }
        else if(other.gameObject.CompareTag("Obstacle")) 
        {
            _gameOver=true;
            //Debug.Log("GAME OVER");
            explosion.Play();
            _animator.SetInteger(DEATHTYPE_INT,Random.Range(1,3)); 
            //El random iría entre 1 y 2 porque el último numero no entra. y al poner enteros, nos devuelve enteros       
            _animator.SetBool(DEATH_B,true);
            dirt.Stop();
            _audioSource.PlayOneShot(crashSound,audioSound);
            Invoke("RestartGame",2f);
        }
    }

    void RestartGame()
    {
        speedMultiplier=1;
        Physics.gravity = new Vector3(0f,-9.81f,0f);
        //SceneManager.UnloadSceneAsync("Prototype 3");
        SceneManager.LoadSceneAsync("Prototype 3",LoadSceneMode.Single);        
    }
}
