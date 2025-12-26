using UnityEngine;

public class RangeEnemyTriggerEnterManager : MonoBehaviour
{
    private RangeEnemyHealthManager rangeEnemyHealthManager;
    private PlayerAttackDamageManager playerAttackDamage;
    string _BulletPrefabName = "PlayerBullet";
    void Awake()
    {
        rangeEnemyHealthManager = GetComponentInChildren<RangeEnemyHealthManager>();
        playerAttackDamage = GameObject.Find("DamageSystemManager").GetComponent<PlayerAttackDamageManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(_BulletPrefabName))
        {
            rangeEnemyHealthManager.RangeEnemyHealth -= playerAttackDamage.playerAttackDamageAmmount;
            Destroy(other.gameObject);
        }
    }
}
