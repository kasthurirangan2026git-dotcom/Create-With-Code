using UnityEngine;

public class LongRangeEnemytriggerEnterManager : MonoBehaviour
{
    
    private PlayerAttackDamageManager playerAttackDamage;
    private LongRangeEnemyHealthManager longRangeEnemyHealthManager;
    private string _BulletPrefabTag= "PlayerBullet";
     void Awake()
    {
        playerAttackDamage = GameObject.Find("DamageSystemManager").GetComponent<PlayerAttackDamageManager>();
        longRangeEnemyHealthManager = GetComponentInChildren<LongRangeEnemyHealthManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_BulletPrefabTag))
        {
            longRangeEnemyHealthManager.longRangeEnemyHealth -= playerAttackDamage.playerAttackDamageAmmount;
            Destroy(other.gameObject);
        }
    }
}
