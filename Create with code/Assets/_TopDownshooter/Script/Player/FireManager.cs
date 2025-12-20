using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform _playerTransform;

    public static FireManager fireManager;

    private AudioClip audioClip;

    GameObject _projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
    }

    void OnFire()
    {
       _projectile = Instantiate(projectile,_playerTransform.position,_playerTransform.rotation );
        Debug.Log("fire");
    
        
    }
}
