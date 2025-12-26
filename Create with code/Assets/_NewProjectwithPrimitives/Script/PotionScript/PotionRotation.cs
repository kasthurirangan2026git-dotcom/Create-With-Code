using UnityEngine;

public class PotionRotation : MonoBehaviour
{
  
  private Transform _Potion;
  private float _RotationSpeed = 70f;
    void Awake()
    {
        _Potion = this.gameObject.transform;
    }
    void Update()
    {
        _Potion.transform.Rotate(Vector3.left * _RotationSpeed * Time.deltaTime,Space.World );
    }
}
