using Unity.VisualScripting;
using UnityEngine;


public class AnimalMovingLeft : MonoBehaviour
{

    private float _AnimalSpeed = 7;
    protected bool IsGameOver= false;
    GameOverManager gameOverManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager =  FindAnyObjectByType<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(Vector3.forward * _AnimalSpeed * Time.deltaTime);
        if(this.transform.position.x < -30.0f)
        {
            Destroy(gameObject);
        }
        
    }
}
