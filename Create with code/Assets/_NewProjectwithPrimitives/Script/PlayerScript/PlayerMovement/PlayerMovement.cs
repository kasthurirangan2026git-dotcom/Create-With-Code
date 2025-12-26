using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float _playerSpeed = 10.0f;

    
    private Vector2 _inputValue;
    private Vector3 _movementValue;

    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private GameObject _PlayerFirePoint;
    private PlayerBulletSpawnManager playerBulletSpawnManager;

    void Start()
    {
        playerBulletSpawnManager = _PlayerFirePoint.GetComponent<PlayerBulletSpawnManager>();
    }

    void Update()
    {
        _movementValue = new Vector3 (_inputValue.x,0,0);
        _playerTransform.Translate(_movementValue * _playerSpeed * Time.deltaTime);
    }

    void OnMove(InputValue inputValue)
    {
        _inputValue = inputValue.Get<Vector2>();
    }
    void OnFire()
    {
        playerBulletSpawnManager.BulletSpawn();
       
    }


}
