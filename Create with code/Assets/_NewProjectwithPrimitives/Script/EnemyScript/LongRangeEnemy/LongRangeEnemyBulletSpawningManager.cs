using UnityEngine;

public class LongRangeEnemyBulletSpawningManager : MonoBehaviour
{
  [SerializeField]
    private GameObject _LongRangeEnemybulletPrefab;

    private LongRangeEnemyMovement _LongRangeEnemyMovement;
    private float _FireCooldown;
    private float _FireResetTime = 5;
    void Awake()
    {
        _LongRangeEnemyMovement = GetComponentInParent<LongRangeEnemyMovement>();
        

    }

    void Update()
    {
        FireBullet();
    }



    void FireBullet()
    {
        if(_LongRangeEnemyMovement.LongRangeInAttackPosition)
        {
            if(Time.time > _FireCooldown)
            {
               GameObject BulletGameObject = Instantiate(_LongRangeEnemybulletPrefab,this.transform.position,Quaternion.identity);
               BulletGameObject.tag = "LongRangeEnemyBullet";

                _FireCooldown = Time.time + _FireResetTime;
            }
            
        }
            
    }
}
