using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{ private float _PowerUpRotateSpeed = 60f;
    void Update()
    {
        transform.Rotate(Vector3.up* _PowerUpRotateSpeed * Time.deltaTime);
    }
}
