
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContorlManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerRigidbody;

    private Vector2 _playerMovementInput,_focalPointRotateInputValue;
    
    private float _playerMovingForce = 5f;
    
    [SerializeField]
    private Transform _focalPointTransform;

    private Vector3 _focalPointRotateValue;

    private float _focalPointRotationSpeed = 120f;


    void OnMove(InputValue inputValue)
    {
        _playerMovementInput = inputValue.Get<Vector2>();
        _focalPointRotateInputValue = inputValue.Get<Vector2>();
        _focalPointRotateValue = new Vector3(0,_focalPointRotateInputValue.x,0);
    }    

    void PlayerMove(float movementValue)
    { 
        _playerRigidbody.AddForce( _focalPointTransform.forward * _playerMovingForce * movementValue);
    }

     void FocalPointRotator(float speed)
    {
        _focalPointTransform.transform.Rotate(_focalPointRotateValue * speed * Time.deltaTime);
    }

    void Update()
    {
        FocalPointRotator(_focalPointRotationSpeed); 
        PlayerMove(_playerMovementInput.y);
    }
    

}
