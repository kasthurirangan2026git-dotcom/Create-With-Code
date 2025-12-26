using System.Collections;
using UnityEngine;

public class EnemySpawnLogicManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _EnemyPrefab;

    private int _EnemyCount;
    private bool _IsGameOver = false;
    public bool isGameOver
    {
        get
        {
            return _IsGameOver;
        }
        set
        {
            _IsGameOver = value;
        }
    }

    void Start()
    {
        InvokeRepeating("MaleeEnemySpawn",10f,20f);
    }
    void Update()
    {
        _EnemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (!_IsGameOver)
        {
            EnemySpawn();
        }
        else if (_IsGameOver)
        {
            CancelInvoke("MaleeEnemySpawn");
            return;
        }
        
    }


    void EnemySpawn()
    {
        if(_EnemyCount == 0)
        {
            RangeEnemySpawn(Random.Range(0,2));
            LongRangeEnemySpawn(Random.Range(0,2));
        }
    }

    Vector3 RandomSpawnPosition()
    {
        return new  Vector3 (Random.Range(-12,12),5,10); 
    }



    void RangeEnemySpawn(int enemyCount)
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(_EnemyPrefab[0],RandomSpawnPosition(),_EnemyPrefab[0].transform.rotation);
        }
            
    }
    void LongRangeEnemySpawn(int enemyCount)
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(_EnemyPrefab[1],RandomSpawnPosition(),_EnemyPrefab[1].transform.rotation);    
        }
        
    }
    void MaleeEnemySpawn()
    {  
        Instantiate(_EnemyPrefab[2],RandomSpawnPosition(),_EnemyPrefab[2].transform.rotation);
    }
    
    
    
}
