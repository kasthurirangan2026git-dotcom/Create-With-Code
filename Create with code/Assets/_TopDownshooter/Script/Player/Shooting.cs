using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float _Speed =  30.0f;
    [SerializeField]
    private Transform projectilePos;

    private AnimalHealthManager animalHealthManager;
    private AnimalDeadManager animalDeadManager;

    

    void Awake()
    {
        
        animalDeadManager = FindAnyObjectByType<AnimalDeadManager>();
    }
    // Update is called once per frame
    void Update()
    {
        projectilePos.transform.Translate(Vector3.forward * _Speed * Time.deltaTime);

        if (this.gameObject.transform.position.z > 20f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {Debug.Log((string)other.tag);
        if (other.CompareTag("Animal"))
        {   
           animalHealthManager =  other.GetComponent<AnimalHealthManager>();
           if(animalHealthManager  != null)
            {
                animalHealthManager.animalHealth -= 1;

                if(animalHealthManager.animalHealth == 0)
                {
                    animalDeadManager.IsDead(other.gameObject);
                    
                }
            }

           
        }
        
        Destroy(this.gameObject);
       
        
        
    }
}
