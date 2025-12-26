using UnityEngine;

public class PlayerSmashPowerIndicator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField]
   private float _RotationSpeed = 100f;
   [SerializeField]
   private Transform _playerTransform;
    // Update is called once per frame
    void Update()
    {
       
        this.gameObject.transform.position = _playerTransform.transform.position + new Vector3 (0,2f,0);
        transform.Rotate(Vector3.up * _RotationSpeed * Time.deltaTime);
    }
}
