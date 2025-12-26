using UnityEngine;

public class MaleeTriggerEnterManager : MonoBehaviour
{
    private MaleeHealthManager maleeHealthManager;
    private PlayerAttackDamageManager playerAttackDamage;
    string _BulletPrefabTag = "PlayerBullet";
    void Awake()
    {
        maleeHealthManager = GetComponentInChildren<MaleeHealthManager>();
        playerAttackDamage = GameObject.Find("DamageSystemManager").GetComponent<PlayerAttackDamageManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_BulletPrefabTag))
        {
            maleeHealthManager.maleeEnemyHealth -= playerAttackDamage.playerAttackDamageAmmount;
            Destroy(other.gameObject);
        }
    }

}
