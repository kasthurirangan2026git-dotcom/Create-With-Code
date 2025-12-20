using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class PlayertriggerEnterManager : MonoBehaviour
{
    private Rigidbody _EnemyRigitBody;
    private Transform _Enemytransform;

    [SerializeField]
    private bool _HasPowerUp ;
    [SerializeField]
    private float _pushingStrength = 100f;
    [SerializeField]
    private int _powerUpCooldown = 7;
    [SerializeField]
    private GameObject _PlayerPowerUpIndicator;

    void Start()
    {
        _PlayerPowerUpIndicator.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _HasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCooldown(_powerUpCooldown));
            _PlayerPowerUpIndicator.gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBall" && _HasPowerUp)
        {
            _EnemyRigitBody = collision.gameObject.GetComponent<Rigidbody>();
            _Enemytransform = collision.gameObject.GetComponent<Transform>();
            Vector3 PushingDraction = _Enemytransform.position - transform.position;
            _EnemyRigitBody.AddForce(PushingDraction * _pushingStrength,ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCooldown(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _HasPowerUp = false;
        _PlayerPowerUpIndicator.gameObject.SetActive(false);
    }
}
