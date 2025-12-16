using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    Vector3 _value ;
    float _speed =10f;
    float _xRange = 16;
    [SerializeField]
    private float _horizontalInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    _value = new Vector3(_horizontalInput , 0,0);

        transform.Translate(_value * _speed * Time.deltaTime);

        if (transform.position.x < -_xRange )
        {
            transform.position = new Vector3 (-_xRange,transform.position.y,transform.position.z);
        }
        if (transform.position.x > _xRange )
        {
            transform.position = new Vector3 (_xRange,transform.position.y,transform.position.z);
        }
    
    }

    void OnHorizontalMove(InputValue inputValue)
    {
        _horizontalInput = inputValue.Get<float>();
    }

}
