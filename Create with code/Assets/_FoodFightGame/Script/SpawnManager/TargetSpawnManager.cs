using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _TargetPrefab;
    private int _TimeBetweenSpawn = 2;
    private FoodNinjaHealthManager  foodNinjaGameOverManager;
    [SerializeField]
    private GameObject _GameStateManagerGameObject;
    private GameObject _InstanceGameObject;
    private GameStateManager gameStateManager;
    private bool _IsSpawnStart = false;
    private int _Difficulty;
    public int difficultyValue
    {
        get
        {
            return 0;
        }
        set
        {
            _Difficulty = value;
        }
    }

    void Awake()
    {
        foodNinjaGameOverManager = _GameStateManagerGameObject.GetComponent<FoodNinjaHealthManager>();
        gameStateManager = _GameStateManagerGameObject.GetComponent<GameStateManager>();
        
    }
   
    void Update()
    {
        if(gameStateManager.isGameStart && !_IsSpawnStart)
        {
            TagSetter();
            StartCoroutine(SpawnEnemy());
            _IsSpawnStart = true;
            gameStateManager.isGameActive = true;
        }
    }

    private IEnumerator SpawnEnemy()
    {   
        while (foodNinjaGameOverManager.playerHealth > 0)
        {
            yield return new WaitForSeconds(_Difficulty);
            int index = Random.Range(0,_TargetPrefab.Count);
           _InstanceGameObject = Instantiate(_TargetPrefab[index]);
        }
        Destroy(_InstanceGameObject);
    }
    private void TagSetter()
    {
        _TargetPrefab[0].tag = "TargetBomb";
        _TargetPrefab[1].tag = "TargetCommon";
        _TargetPrefab[2].tag = "TargetRare";
        _TargetPrefab[3].tag = "TargetEpic";
    }

}
