using System.Collections;
using System.Runtime.CompilerServices;

using Unity.VisualScripting;
using UnityEngine;

public class PlayertriggerEnterManager : MonoBehaviour
{
    private Rigidbody _EnemyRigitBody;
    private Transform _Enemytransform;
   
    [SerializeField]
    private float _pushingStrength = 100f;
    private int _powerUpCooldown = 7;
    
    [SerializeField]
    private GameObject _PlayerPowerUpIndicator;
    [SerializeField]
    private GameObject _PlayerShootingPowerUpIndicator;

    private GameObject _tmpRocket;
    [SerializeField]
    private GameObject _RocketPrefab;
    private PowerupType _CurrentPowerupType = PowerupType.none;
    public PowerupType CurrentPowerupType
    {
        get
        {
            return _CurrentPowerupType;
        }
    }

    private float _hangTime = 0.7f;
    private float _SmashStrength = 5f;
    private float _ExplotionForce = 50f;
    private float _ExplotionRadius = 12f;
    private float _SmashStartPositionY;
    private bool _IsSmash;
    public bool isSmashing
    {
        get
        {
            return _IsSmash;
        }
        set
        {
            _IsSmash = value;
        }
    }

    private Rigidbody _PlayerRigitBody;
    [SerializeField]
    private GameObject _PlayerSmashPowerUpIndicatorGameObject;
    

    void Start()
    {
        _PlayerRigitBody = GetComponent<Rigidbody>();
        IndicatorDeactivator(false);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PushPower"))
        {
        
            Destroy(other.gameObject);
            _CurrentPowerupType = other.gameObject.GetComponent<PowerUpManager>().powerupType;    
            StartCoroutine(PowerUpCooldown(_powerUpCooldown));
            _PlayerPowerUpIndicator.gameObject.SetActive(true);

        }else if (other.CompareTag("RocketLancher"))
        {
            Destroy(other.gameObject);
             _CurrentPowerupType = other.gameObject.GetComponent<PowerUpManager>().powerupType;
             StartCoroutine(PowerUpCooldown(_powerUpCooldown));
             _PlayerShootingPowerUpIndicator.gameObject.SetActive(true);
             
        }
        else if (other.CompareTag("SmashPower"))
        {
            _CurrentPowerupType = other.gameObject.GetComponent<PowerUpManager>().powerupType;
             StartCoroutine(PowerUpCooldown(_powerUpCooldown));
             _PlayerSmashPowerUpIndicatorGameObject.gameObject.SetActive(true);
             Destroy(other.gameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBall" && _CurrentPowerupType == PowerupType.PushBack)
        {
            _EnemyRigitBody = collision.gameObject.GetComponent<Rigidbody>();
            _Enemytransform = collision.gameObject.GetComponent<Transform>();
            Vector3 PushingDraction = _Enemytransform.position - transform.position;
            _EnemyRigitBody.AddForce(PushingDraction * _pushingStrength,ForceMode.Impulse);
            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to " + _CurrentPowerupType.ToString());
        }
    }

    IEnumerator PowerUpCooldown(int timer)
    {
        yield return new WaitForSeconds(timer);
        _CurrentPowerupType = PowerupType.none;
        IndicatorDeactivator(false);

    }

 
    public void LanchRockets()
    {
        foreach(var enemy in FindObjectsByType<EnemyAliveStatus>(FindObjectsSortMode.None))
        {
            _tmpRocket = Instantiate(_RocketPrefab,transform.position+Vector3.up,Quaternion.identity);
            if( _tmpRocket.GetComponent<RocketLancherBehaviour>() != null)
            {
                 _tmpRocket.GetComponent<RocketLancherBehaviour>().RocketFire(enemy.transform);
            }
           
            

        }
    }

    public IEnumerator Smash()
    {
        var enemy = FindObjectsByType<EnemyAliveStatus>(FindObjectsSortMode.None);

        _SmashStartPositionY = transform.position.y;

        float jumptime = Time.time + _hangTime;

        while(Time.time < jumptime)
        {
            _PlayerRigitBody.linearVelocity = new Vector2(0, _SmashStrength * 2);
            yield return null;
        }

        while (transform.position.y > _SmashStartPositionY)
        {
            _PlayerRigitBody.linearVelocity = new Vector2(_PlayerRigitBody.linearVelocity.x, -_SmashStrength * 3f);
            yield return null;
        }

        for(int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemy[i].GetComponent<Rigidbody>().AddExplosionForce(_ExplotionForce,this.transform.position,_ExplotionRadius,0.0f,ForceMode.Impulse);

            }
            
            _IsSmash = false;



    }
    
}

void IndicatorDeactivator(bool state)
    {
        _PlayerPowerUpIndicator.gameObject.SetActive(state);
        _PlayerShootingPowerUpIndicator.gameObject.SetActive(state);
        _PlayerSmashPowerUpIndicatorGameObject.gameObject.SetActive(state);
    }
}
