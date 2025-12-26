using UnityEngine;

public class EnemyAliveStatus : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    private EnemyWaveManager enemyWaveManager;

    void Awake()
    {
        enemySpawnManager = GameObject.Find("Spawn Manager").GetComponent<EnemySpawnManager>();
        enemyWaveManager = GameObject.Find("Enemy Wave Manager").GetComponent<EnemyWaveManager>();
    }


    void Update()
    {
        if(this.gameObject.transform.position.y < -5f)
        {
            
            enemyWaveManager.AllEnemyDeadChecking();
            Destroy(gameObject);
        }
    }
}
