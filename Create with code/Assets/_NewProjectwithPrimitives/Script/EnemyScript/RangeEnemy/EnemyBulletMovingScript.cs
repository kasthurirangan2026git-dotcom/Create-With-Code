using UnityEngine;

public class EnemyBulletMoving : MonoBehaviour
{
    
    private Transform _BulletTransform;
    private float _BulletSpeed = 10f;
    void Awake()
    {
        _BulletTransform = this.transform;
    }

    
    void Update()
    {
        _BulletTransform.transform.Translate(Vector3.back*Time.deltaTime*_BulletSpeed);
        if(_BulletTransform.transform.position.z < -6.66)
        {
            Destroy(gameObject);
        }
    }
}
