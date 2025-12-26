using UnityEngine;

public class PlayerShootingPowerVisual : MonoBehaviour
{
     [SerializeField]
   private float _RotationSpeed = 100f;
   [SerializeField]
   private Transform _playerTransform;
    // Update is called once per frame
    void Update()
    {
       
        this.gameObject.transform.position = _playerTransform.transform.position + new Vector3 (0,.8f,0);
        transform.Rotate(Vector3.up * _RotationSpeed * Time.deltaTime);
    }
}

