using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
  
    
    private float _PlayerMovementspeed = 20;
    private float _PlayerRotationSpeed = 200f;

    private float moveZ,moveX;
    private Rigidbody _PlayerRigidBody;
    


    
   
    void Start()
    {
        
      _PlayerRigidBody = gameObject.GetComponent<Rigidbody>();

       Application.targetFrameRate = 60;
        
    }


    
    public void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        moveX = movementVector.x;
        moveZ = movementVector.y;
    }

    void Update(){
        
        Vector3 playerMovement = new Vector3(0f,0f,moveZ);
        transform.Rotate(Vector3.up * moveX * _PlayerRotationSpeed * Time.deltaTime);
        
        
       
    }
     private void FixedUpdate() {
        Vector3 playerMovement = new Vector3(0f,0f,moveZ);
        transform.Translate(playerMovement * _PlayerMovementspeed * Time.deltaTime);
     }
     
}
