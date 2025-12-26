using System.Collections;
using UnityEngine;

public class MaleeEnemyMovement : MonoBehaviour
{
  private GameObject _Player;
  private Rigidbody _MaleeRigidbody;
  private float _MaleeEnemyMovementSpeed = 10.0f;
  private float _MaleeSlamAttckStrength = 65f;
  private float _MaleeEnemyZPositionLimit = -1;
  private float _EnemyDestroyTimer = 2f;
  private bool _IsReadyToAttack,_IsSlamAttackAvailable;
  private int _SlamAttackChargeTime = 4;
  public int slamAttackChargeTime
    {
        get
        {
            return _SlamAttackChargeTime;
        }
    }
  public bool isReadyToAttack
    {
        get
        {
            return _IsReadyToAttack;
        }
    }

    void Awake()
    {
        if(GameObject.Find("Player").gameObject != null)
        {
            _Player = GameObject.Find("Player").gameObject;   
        }
        _MaleeRigidbody = GetComponent<Rigidbody>();
        _IsSlamAttackAvailable = true;
    }

    void Update()
    {
        MaleeEnemyMoveToWards();
        MaleeEnemySlamAttack();
    }

    void MaleeEnemyMoveToWards()
    {
        if(transform.position.z > _MaleeEnemyZPositionLimit && !_IsReadyToAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position,_Player.transform.position,_MaleeEnemyMovementSpeed * Time.deltaTime);
        }
        else
        {
            _IsReadyToAttack = true;
        }
        
    }
    void MaleeEnemySlamAttack()
    {
        if (_IsSlamAttackAvailable && _IsReadyToAttack)
        {
            StartCoroutine(SlamAttackCharging(_SlamAttackChargeTime));
           return;
        }
        
        
    }
    
    IEnumerator SlamAttackCharging(int SlamAttackCharging)
    {
        yield return new WaitForSeconds(SlamAttackCharging);
        
        if (_IsSlamAttackAvailable)
        {
            Vector3 dirctionToGo = (_Player.transform.position - transform.position).normalized;
            _MaleeRigidbody.AddForce(dirctionToGo * _MaleeSlamAttckStrength * Time.deltaTime,ForceMode.Impulse);
            _IsSlamAttackAvailable = false;
            Destroy(gameObject,_EnemyDestroyTimer);
        }
        
         
        
      
    }
    
}
