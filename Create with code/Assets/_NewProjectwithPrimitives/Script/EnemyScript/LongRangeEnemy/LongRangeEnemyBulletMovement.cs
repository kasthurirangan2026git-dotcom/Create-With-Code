using UnityEngine;

public class LongRangeEnemyBulletMovement : MonoBehaviour
{
    private float _BulletStrength = 8f;
    private Vector3 _PlayerPostition;
    private GameObject _Player;
    private Rigidbody _BulletRigidbody;
    private float _BulletLifeSpawn = 3f;

    void Start()
    {
        _Player = GameObject.Find("Player").gameObject;
        _BulletRigidbody = GetComponent<Rigidbody>();

        
    }

    void Update()
    {
        _PlayerPostition = (_Player.transform.position - transform.position).normalized;
        _BulletRigidbody.AddForce(_PlayerPostition * _BulletStrength * Time.deltaTime,ForceMode.Impulse);
       
        Destroy(this.gameObject,_BulletLifeSpawn);
    }

}
