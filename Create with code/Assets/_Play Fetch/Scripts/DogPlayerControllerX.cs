using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    bool fire = false;
    float _current = 1.2f ;
    float _cooldown = 1.2f;
    void Awake()
    {
        Application.targetFrameRate = 120;      
    }

    // Update is called once per frame
    void Update()
    {

        // On spacebar press, send dog
        if (fire == true && Time.time > _current )
        {   
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            fire = false;

            _current = _cooldown + Time.time;
            
            

        }
    }

    void OnFire()
    {
        fire = true;
    }
}
