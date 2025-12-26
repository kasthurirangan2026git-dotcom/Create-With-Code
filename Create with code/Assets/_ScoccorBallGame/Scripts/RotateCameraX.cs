using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float speed ;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        
        //

        transform.position = player.transform.position; // Move focal point with player

    }

    
}
