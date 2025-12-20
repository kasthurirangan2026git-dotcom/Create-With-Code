using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerControllerX : MonoBehaviour
{

    
    private float speed =8;
    public float rotationSpeed;
    public float verticalInput;
    private float moveY;
    

    

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
        void OnFly(InputValue inputValue)
            {
                Vector2 _planeMove =  inputValue.Get<Vector2>();
                moveY = _planeMove.y;
               
            }
    // Update is called once per frame
    void Update()
    {
        Vector3 MovePos = new Vector3(moveY,0,0);

        

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(MovePos * rotationSpeed * Time.deltaTime);
    }
    
    

}
