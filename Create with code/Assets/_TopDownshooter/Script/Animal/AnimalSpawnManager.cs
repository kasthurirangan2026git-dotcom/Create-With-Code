using System.CodeDom.Compiler;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class AnimalSpawnManager : MonoBehaviour
{   [SerializeField]
    private GameObject[] AnimalPrefab = new GameObject[4];
    [SerializeField]
    private GameObject[] AnimalPrefabRight = new GameObject[4];
    [SerializeField]
    private GameObject[] AnimalPrefabLeft = new GameObject[4];
    private int index;
    private int spawnRange; 
    private int sideSpawnRange;
    Vector3 Pos;
    Vector3 posLeft;
    Vector3 posRight;

    private GameObject animal,animalright,animalleft;   

    private string _prefabTag = "Animal";
    
    

    void Start()
    {
       InvokeRepeating("AnimalSpawnDelay",1,2);
    }

    void AnimalSpawnDelay(){
        spawnRange = UnityEngine.Random.Range(-12,12);
        Pos = new Vector3(spawnRange, 0, 27);
        index = UnityEngine.Random.Range(0,AnimalPrefab.Length);
       animal = Instantiate(AnimalPrefab[index],Pos,transform.rotation);
    // Side spawn
       sideSpawnRange = UnityEngine.Random.Range(-1,14);
        posLeft = new Vector3(-24, 0, sideSpawnRange);
        index = UnityEngine.Random.Range(0,AnimalPrefabLeft.Length);
       animalright = Instantiate(AnimalPrefabLeft[index],posLeft,AnimalPrefabLeft[0].transform.rotation);

       sideSpawnRange = UnityEngine.Random.Range(-1,14);
        posRight = new Vector3(24, 0, sideSpawnRange);
        index = UnityEngine.Random.Range(0,AnimalPrefabRight.Length);
       animalleft = Instantiate(AnimalPrefabRight[index],posRight,AnimalPrefabRight[0].transform.rotation);

       animal.tag = _prefabTag;
       animalright.tag = _prefabTag;
       animalleft.tag = _prefabTag;

       



    }

 
}
