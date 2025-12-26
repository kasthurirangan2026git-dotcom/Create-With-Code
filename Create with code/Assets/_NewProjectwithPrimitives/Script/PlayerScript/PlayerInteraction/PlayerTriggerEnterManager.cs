using Unity.VisualScripting;
using UnityEngine;

public class PlayerTriggerEnterManager : MonoBehaviour
{
    private PlayerHealthManager playerHealthManager;
    private const string _RangeEenemyBulletTag = "RangeEnemyBullet";
    private const string _LongRangeEnemyBulletTag = "LongRangeEnemyBullet";
    private const string _MaleeEnemyTag = "MaleeEnemy";
    private const string _HealthPotionTag = "HealthPotion";
    private EnemyDamage enemyDamage;
    private PotionPowers potionPowers;
    private const string _GameDamageSystemGameObjectName = "DamageSystemManager"; 
    void Awake()
    {
        enemyDamage = GameObject.Find(_GameDamageSystemGameObjectName).GetComponent<EnemyDamage>();
        potionPowers = enemyDamage.gameObject.GetComponent<PotionPowers>();
        Debug.Log(potionPowers);
        playerHealthManager = GetComponentInChildren<PlayerHealthManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case _RangeEenemyBulletTag:
            playerHealthManager.playerHealth -= enemyDamage.rangeEnemyAttackDamage;
            Destroy(other.gameObject);
            break;

            case _LongRangeEnemyBulletTag:
            playerHealthManager.playerHealth -= enemyDamage.longRangeEnemyAttackDamage;
            Destroy(other.gameObject);
            break;

            case _MaleeEnemyTag:
            playerHealthManager.playerHealth -= enemyDamage.maleeEnemyAttackDamage;
            Destroy(other.gameObject);
            break;
            case _HealthPotionTag:
            playerHealthManager.playerHealth += potionPowers.healthPotionPower;
            Destroy(other.gameObject);
            break;
        }
        
    }
}
