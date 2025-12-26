using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSystemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _PlayerBody;
    [SerializeField]
    private GameObject _PlayerMovement;
    [SerializeField]
    private GameObject _SpawnManager;
    [SerializeField]
    private GameObject _PlayerHealthManger;
    private PlayerHealthManager playerHealthManager;
    [SerializeField]
    private GameObject _GameOverScreen;
    

    private EnemySpawnLogicManager enemySpawnLogicManager;
    private PotionSpawnManager potionSpawnManager;

    private float _EnemyMovementSpeed = 10f;


    void Awake()
    {
        playerHealthManager = _PlayerHealthManger.GetComponent<PlayerHealthManager>();
        enemySpawnLogicManager = _SpawnManager.GetComponent<EnemySpawnLogicManager>();
        potionSpawnManager = _SpawnManager.GetComponent<PotionSpawnManager>();
        _GameOverScreen.SetActive(false);
       
    }
    void Update()
    {
       GameOver();


    }

    void GameOver()
    {
         if(playerHealthManager.playerHealth <= 0)
        {
            _PlayerBody.gameObject.SetActive(false);
            _PlayerMovement.gameObject.SetActive(false);
            enemySpawnLogicManager.isGameOver = true;
            potionSpawnManager.isGameOver = true;
            GameObject game = FindAnyObjectByType<Enemy>().gameObject;
            game.transform.Translate(Vector3.back * _EnemyMovementSpeed *Time.deltaTime);
             _GameOverScreen.SetActive(true);
            
            
        }
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(2);
    }

}
