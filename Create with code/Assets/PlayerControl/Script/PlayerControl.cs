using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
  
    
    private float playerspeed = 50;

    private float moveZ,moveX;
    [SerializeField]
    public Rigidbody rb;



    
   
    void Start()
    {
        
       // rb = GetComponent<Rigidbody>();

       Application.targetFrameRate = 60;
        
    }


    
    public void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        moveX = movementVector.x;
        moveZ = movementVector.y;
    }

    void Update(){
        
        Vector3 vector3 = new Vector3(moveX,0f,moveZ);
        rb.AddForce(vector3*playerspeed);
        //transform.Translate(vector3 * playerspeed * Time.deltaTime);
    }

}
