using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce=40;
    
    public float floatReboot=10;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip boingSound;
    public AudioClip explodeSound;
    private float maxPositionY = 13f ;
    private bool touchTop;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * floatReboot, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        //Limito el margen superior
        touchTop = (transform.position.y > maxPositionY);
        if (touchTop)
        {
            //transform.position = new Vector3(transform.position.x,maxPositionY,transform.position.z);
            //playerRb.AddForce(Vector3.down * floatReboot);
            playerRb.AddForce(Vector3.down * playerRb.velocity.y);
             
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && !touchTop)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            //Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground")&&!gameOver)
        {
            //fireworksParticle.Play();
            playerAudio.PlayOneShot(boingSound, 1.0f);
            playerRb.AddForce(Vector3.up * floatReboot, ForceMode.Impulse);
        }

    }

}
