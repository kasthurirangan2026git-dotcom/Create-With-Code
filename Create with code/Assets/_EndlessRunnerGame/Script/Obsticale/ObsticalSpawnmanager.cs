using UnityEngine;

public class ObsticalSpawnmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject ObsticalGameObject;

     private int _SpawnDelay = 3;
    
     private Vector3 SpawnPosition = new Vector3(20,0,0);
     string _methodName ="ObsticalSpawn";

    void Start()
    {
        InvokeRepeating(_methodName,_SpawnDelay,Random.Range(3,5));
    }

    void ObsticalSpawn()
    {
        Instantiate(ObsticalGameObject,SpawnPosition,this.transform.rotation);
    }
public void StopInvoking(string methodName)
    {
        CancelInvoke(methodName);
    }
}