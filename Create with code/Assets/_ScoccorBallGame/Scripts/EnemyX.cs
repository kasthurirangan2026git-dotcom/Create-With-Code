using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
   
    
    private Rigidbody enemyRb;
    
    private GameObject playerGoal;

    private ScoccerSpawnManagerX spawnManagerX;

    // Start is called before the first frame update
    void Awake()
    {
      spawnManagerX =  GameObject.Find("Spawn Manager").GetComponent<ScoccerSpawnManagerX>();  
    }
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectsWithTag("PlayerGoal")[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there        
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * spawnManagerX.enemySpeed * Time.deltaTime);
        Debug.Log(spawnManagerX.enemySpeed);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
