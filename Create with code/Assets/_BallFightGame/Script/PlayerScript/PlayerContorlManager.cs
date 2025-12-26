
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContorlManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerRigidbody;

    private Vector2 _playerMovementInput,_focalPointRotateInputValue;
    
    private float _playerMovingForce = 4f;
    
    [SerializeField]
    private Transform _focalPointTransform;

    private Vector3 _focalPointRotateValue;

    private float _focalPointRotationSpeed = 120f;
    [SerializeField]
    private GameObject _PlayerTriggerEnterManagerGameObject;
    private PlayertriggerEnterManager _PlayertriggerEnterManager;
    
    void Awake()
    {
        _PlayertriggerEnterManager = _PlayerTriggerEnterManagerGameObject.GetComponent<PlayertriggerEnterManager>();
    }





    void OnMove(InputValue inputValue)
    {
        _playerMovementInput = inputValue.Get<Vector2>();
        _focalPointRotateInputValue = inputValue.Get<Vector2>();
        _focalPointRotateValue = new Vector3(0,_focalPointRotateInputValue.x,0);

    }
    void OnFire()
    {
        Debug.Log(_PlayertriggerEnterManager.CurrentPowerupType.ToString());
        if(_PlayertriggerEnterManager.CurrentPowerupType == PowerupType.RocketHoming)
        {
            _PlayertriggerEnterManager.LanchRockets();
            return;
        }
        else if(_PlayertriggerEnterManager.CurrentPowerupType == PowerupType.SmashPower && !_PlayertriggerEnterManager.isSmashing)
        {
            _PlayertriggerEnterManager.isSmashing = true;
            _PlayertriggerEnterManager.StartCoroutine(_PlayertriggerEnterManager.Smash());
        }
        
        return;
       
    
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
