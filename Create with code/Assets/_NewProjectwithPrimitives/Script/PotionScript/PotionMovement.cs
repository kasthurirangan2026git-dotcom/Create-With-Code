using UnityEngine;

public class PotionMovement : MonoBehaviour
{

    private Transform _Potion;
    private float _MovementSpeed = 10f;
    private string _PotionGameObjectTag = "HealthPotion";
    void Awake()
    {
        _Potion = GetComponent<Transform>();
        gameObject.tag = _PotionGameObjectTag;
    
    }
    void Update()
    {
        _Potion.transform.Translate(Vector3.back* _MovementSpeed*Time.deltaTime);
        if(this.transform.position.z < -10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
