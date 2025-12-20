using UnityEngine;

public class PlayerMovmentLimit : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransfrom;

    private float _playerMovementLimit = 8.0f;

    private Vector3 PlayerMovementLimitPosition(float Value)
    {
        return new Vector3(Value,_playerTransfrom.position.y,_playerTransfrom.position.z);
    }

    private void PlayerMovementController()
    {
        if (_playerTransfrom.position.x < -_playerMovementLimit)
        {
            _playerTransfrom.position = PlayerMovementLimitPosition(-_playerMovementLimit);
        }
        if(_playerTransfrom.position.x > _playerMovementLimit)
        {
            _playerTransfrom.position = PlayerMovementLimitPosition(_playerMovementLimit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementController();
    }
}
