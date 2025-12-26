using UnityEngine;
using UnityEngine.Animations;

public class RangeEnemyBulletSpawningManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _RangeEnemybulletPrefab;

    private RangeEnemyMovement rangeEnemyMovement;
    private float _FireCooldown;
    private float _FireResetTime = 2;
    void Awake()
    {
        rangeEnemyMovement = GetComponentInParent<RangeEnemyMovement>();
        Debug.Log(rangeEnemyMovement);

    }

    void Update()
    {
        FireBullet();
    }



    void FireBullet()
    {
        if(rangeEnemyMovement.inAttackPostiton)
        {
            if(Time.time > _FireCooldown)
            {
               GameObject BulletGameObject = Instantiate(_RangeEnemybulletPrefab,this.transform.position,Quaternion.identity);
               BulletGameObject.tag = "RangeEnemyBullet";

                _FireCooldown = Time.time + _FireResetTime;
            }
            
        }
            
    }
    

}
