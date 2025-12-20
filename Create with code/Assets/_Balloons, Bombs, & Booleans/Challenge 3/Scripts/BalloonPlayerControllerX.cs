using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 3f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    [SerializeField]
    private AudioClip BounceAudio;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void OnJump()
    {
        if(this.gameObject.transform.position.y <= 15f && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        Debug.Log("Jump");
        }
        if(this.gameObject.transform.position.y > 15f)
        {
            playerRb.linearVelocity= Vector3.zero;
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
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    void Update()
    {
        if ( this.transform.position.y <= 1.1f && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 200,ForceMode.Force);
           
            if(this.transform.position.y > .9f )
            { Debug.Log("bellow ground");
                playerAudio.PlayOneShot(BounceAudio, 0.5f);
            }
            

        }
    }

}
