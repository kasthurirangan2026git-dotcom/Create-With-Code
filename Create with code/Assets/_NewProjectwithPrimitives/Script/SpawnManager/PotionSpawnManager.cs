using UnityEngine;

public class PotionSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _PotionGameObejct;
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

    Vector3 RandomSpawnPosition()
    {
        return new  Vector3 (Random.Range(-10,10),5,10); 
    }
    void PotionSpawn()
    {  
            Instantiate(_PotionGameObejct,RandomSpawnPosition(),_PotionGameObejct.transform.rotation);
    }
    void Start()
    {
        InvokeRepeating("PotionSpawn",5f,Random.Range(5,10));
    }
    void Update()
    {
        if (_IsGameOver)
        {
            CancelInvoke("PotionSpawn");
        }
    }
}
