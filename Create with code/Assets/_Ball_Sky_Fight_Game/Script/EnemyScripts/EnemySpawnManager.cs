
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _EnemyPrefab;
    [SerializeField]
    private GameObject _PowerupPrefab;

    private float _SpawnPostionX  = 8f;
    private float _SpawnPostionZ = 8f;
    

    private bool _IsAllEnemyDead = true;

    public bool isAllEnemyDead
    {
        get
        {
            return _IsAllEnemyDead;
        }
        set
        {
            _IsAllEnemyDead = value;
        }
    } 

    private int _EnemyCount;
    private int _PowerupCount;
    private int _MaxPowerUpPerWaveCount = 1;
    private int _MaxEnemyCountPerWave = 1;


    void Start()
    {
        SpawnManager(_MaxEnemyCountPerWave,_MaxPowerUpPerWaveCount);
    }


    void Update()
    {
        _EnemyCount = FindObjectsByType<EnemyAliveStatus>(FindObjectsSortMode.None).Length;
        _PowerupCount = FindObjectsByType<PowerUp>(FindObjectsSortMode.None).Length;


        if(_EnemyCount == 0 )
        {   
            SpawnManager(_MaxEnemyCountPerWave,_MaxPowerUpPerWaveCount);
            _MaxEnemyCountPerWave += 1;
            Debug.Log(_PowerupCount);
           
            if(_PowerupCount > 1)
            {
               _MaxPowerUpPerWaveCount = 0; 
            }
            
               
        }
    }


    Vector3 SpawnPositionRandomzer(GameObject[] gameObject)
    {
        _SpawnPostionX = Random.Range(-_SpawnPostionX,_SpawnPostionX);
        _SpawnPostionZ = Random.Range(-_SpawnPostionZ,_SpawnPostionZ);
       return  new Vector3 (Random.Range(-8f,8),gameObject[0].transform.position.y,Random.Range(-8f,8));
    }
     Vector3 SpawnPositionRandomzer(GameObject gameObject)
    {
        _SpawnPostionX = Random.Range(-_SpawnPostionX,_SpawnPostionX);
        _SpawnPostionZ = Random.Range(-_SpawnPostionZ,_SpawnPostionZ);
       return  new Vector3 (Random.Range(-8f,8),gameObject.transform.position.y,Random.Range(-8f,8));
    }
    

    void SpawnManager( int maxEnemyPerWaveCount, int maxPowerUpPerWaveCount)
    {
        for(int i = 0; i < maxEnemyPerWaveCount; i++)
        {
            GameObject enemyPrefab = Instantiate(_EnemyPrefab[Random.Range(0,_EnemyPrefab.Length)], SpawnPositionRandomzer(_EnemyPrefab), _EnemyPrefab[0].transform.rotation);
            enemyPrefab.gameObject.tag = "EnemyBall";
    
        }
        for(int i = 0 ; i < maxPowerUpPerWaveCount; i++)
        {
            GameObject powerUpPrefab = Instantiate(_PowerupPrefab, SpawnPositionRandomzer(_PowerupPrefab), _PowerupPrefab.transform.rotation);
            powerUpPrefab.gameObject.tag = "Powerup";
        } 
          
    } 

    
    
}
