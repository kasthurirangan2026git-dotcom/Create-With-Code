using UnityEngine;

public class PlayerCollutionDeduction : MonoBehaviour
{   
    
    private PlayerHealthanager healthmanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthmanager = FindAnyObjectByType<PlayerHealthanager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
          healthmanager.playerHealth -= 1;
          Debug.Log(healthmanager.playerHealth);
        }
    }
}
