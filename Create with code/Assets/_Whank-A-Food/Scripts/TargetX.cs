using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TargetX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManagerX gameManagerX;
    public int pointValue;
    public GameObject explosionFx;

    public float timeOnScreen = 0.30f;

    private float minValueX = -3.75f; // the x value of the center of the left-most square
    private float minValueY = -3.75f; // the y value of the center of the bottom-most square
    private float spaceBetweenSquares = 2.5f; // the distance between the centers of squares on the game board
    private Camera _MainCamera;
    void Awake()
    {
        _MainCamera = Camera.main;
        
    }



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition(); 
        StartCoroutine(RemoveObjectRoutine()); // begin timer before target leaves screen

    }

    // When target is clicked, destroy it, update score, and generate explosion

    public void OnClick1(InputAction.CallbackContext callbackContext)
    {
        if(!callbackContext.started)return;
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _MainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "Target")
            {
                if(gameManagerX.isGameActive && hit.collider.gameObject.name != "Skull")
                {
                    Debug.Log(hit.collider.gameObject.name );
                    Destroy(hit.collider.gameObject);
                    gameManagerX.UpdateScore(pointValue);
                    Explode(hit.collider.gameObject.transform);
                    return;
                }
                Explode(hit.collider.gameObject.transform);
                Destroy(hit.collider.gameObject);
                gameManagerX.GameOver();

            }
           
            
        }


    }


    
    


    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex ()
    {
        return Random.Range(0, 4);
    }


    // If target that is NOT the bad object collides with sensor, trigger game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            gameManagerX.GameOver();
        } 

    }

    // Display explosion particle at object's position
    void Explode (Transform pos)
    {
        Instantiate(explosionFx, pos.transform.position, pos.transform.rotation);
    }

    // After a delay, Moves the object behind background so it collides with the Sensor object
    IEnumerator RemoveObjectRoutine ()
    {
        yield return new WaitForSeconds(timeOnScreen);
        if (gameManagerX.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }

    }

}
