
using NUnit.Framework;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private Rigidbody _TargetRigidBody;
    private float _SpawnXPositionLimit = 4;
    private float _TorqueSpeedMin = -10;
    private float _TorqueSpeedMax = 15;
    private float _ForceStrengthMin = 10;
    private float _ForceStrengthMax = 16;


    void Start()
    {
        _TargetRigidBody = GetComponent<Rigidbody>();
        _TargetRigidBody.AddForce(RandomForce(),ForceMode.Impulse);
        _TargetRigidBody.AddTorque(RandomTorque());
        transform.position = RandomPosition();

    }



    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_ForceStrengthMin,_ForceStrengthMax);
    }
    private Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(_TorqueSpeedMin,_TorqueSpeedMax),Random.Range(_TorqueSpeedMin,_ForceStrengthMax),Random.Range(_ForceStrengthMin,_TorqueSpeedMax) * Time.deltaTime);
    }
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-_SpawnXPositionLimit,_SpawnXPositionLimit),-1,0);
    }
    

   
}
