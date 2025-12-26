using System.Collections;
using System.Collections.Generic;
using UnityEngine.ParticleSystemJobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoccerPlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 30;
    private float _CameraSpeed = 200;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    private float _verticalInputX,_verticalInputZ;

    [SerializeField]
    private GameObject _FocalPointGameObject;
    [SerializeField]
    private GameObject _ParticalEffect;
    
    private ParticleSystem dirtEffect;

    bool _Boost;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        dirtEffect = _ParticalEffect.GetComponent<ParticleSystem>();
        focalPoint = GameObject.Find("Focal Point");
        dirtEffect.Stop();
    }

    void Update()
    {
        if(_Boost)
        {
            speed += 60;
            
        }
        else
        {
            speed = 30;
        }
        _Boost =false;
        _FocalPointGameObject.gameObject.transform.position = this.transform.position;

        _FocalPointGameObject.transform.Rotate(Vector3.up, _verticalInputX * _CameraSpeed * Time.deltaTime);
        
        playerRb.AddForce(focalPoint.transform.forward * _verticalInputZ * speed * Time.deltaTime,ForceMode.VelocityChange); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    void OnMove(InputValue inputValue)
    {
        Vector2 PlayerInput = inputValue.Get<Vector2>();
        _verticalInputZ = PlayerInput.y;
        _verticalInputX = PlayerInput.x;
        
        
    }

    void OnFire()
    {
        _Boost = true;
        dirtEffect.Play();
        

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown(powerUpDuration));
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
