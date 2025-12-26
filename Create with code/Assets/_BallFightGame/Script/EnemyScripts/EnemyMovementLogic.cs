
using UnityEngine;

public class EnemyMovementLogic : MonoBehaviour
{

    private float _EnemyFourceSpeed = 2f;

    private Transform _PlayerTransform;

    private Rigidbody _EnemyRigitBody;
   
    private Vector3 _PlayerToEnemyDistance; 

    void Awake()
    {
        _EnemyRigitBody = GetComponent<Rigidbody>();
        _PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
 

    void FixedUpdate()
    {
        _PlayerToEnemyDistance = (_PlayerTransform.transform.position - this.transform.position).normalized;
        EnemyAttackingLogic(_PlayerToEnemyDistance);
        
        
    }

    void EnemyAttackingLogic(Vector3 playerPosition)
    {
        _EnemyRigitBody.AddForce(playerPosition *_EnemyFourceSpeed);
    }
}
