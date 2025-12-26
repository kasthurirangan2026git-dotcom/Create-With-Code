using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
  
  private float _MovementSpeed = 10f;

    void Update()
    {
        this.transform.Translate(Vector3.forward * _MovementSpeed * Time.deltaTime);
        if(this.transform.position.z > 10)
        {
            Destroy(gameObject);
        }
    }
}
