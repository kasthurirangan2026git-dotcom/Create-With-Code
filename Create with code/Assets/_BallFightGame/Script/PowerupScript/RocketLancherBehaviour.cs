using UnityEngine;

public class RocketLancherBehaviour : MonoBehaviour
{

    private bool _IsHoming;
    private float _pushingStrength = 10;
    private Transform _Targettransform;
    private float _RocketSpeed =10;
    private float _AliveTimer = 5;
   

    void Update()
    {
     
        if( _IsHoming && _Targettransform != null)
        {
            
            Vector3 targetDirection = (_Targettransform.transform.position - transform.position ).normalized;
            

             this.transform.position += targetDirection * _RocketSpeed * Time.deltaTime;
             transform.LookAt(_Targettransform);
        }
    }

    public void RocketFire(Transform enemyTransform)
    {
        _Targettransform = enemyTransform;
        _IsHoming = true;
        Destroy(gameObject,_AliveTimer);
        Debug.Log(_Targettransform.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag.ToString());
        if (_Targettransform != null)
        {
            if (collision.gameObject.CompareTag(_Targettransform.tag))
            {
                Rigidbody targetRigitbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = (collision.gameObject.transform.position - transform.position).normalized;
                targetRigitbody.AddForce(away * _pushingStrength,ForceMode.Impulse);
                Debug.Log(_Targettransform.tag.ToString());
                Destroy(gameObject);

            }
        }
    }
}
