using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    Vector3 _value ;
    float _speed =10f;
    float _xRange = 16;
    [SerializeField]
    private Vector2 _horizontalInput;
    private float moveX,moveZ;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {    
        
        _value = new Vector3(moveX , 0,moveZ);

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

    void OnMove(InputValue inputValue)
    {
        _horizontalInput = inputValue.Get<Vector2>();

        moveX = _horizontalInput.x;
        moveZ = _horizontalInput.y;

    }

}
