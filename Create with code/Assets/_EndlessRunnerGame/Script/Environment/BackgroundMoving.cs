using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{

    private Vector3 _BackgroundPosition ;
    private float _BackgroundWidth;
    private float _BackgroundMovingspeed = 15f;

    public void BackgroundMovingspeedContorl(float speed)
    {
        _BackgroundMovingspeed = speed;
    }
    private float _RestPosition;

    void Start()
    {
        _BackgroundPosition = this.transform.position;

        _BackgroundWidth = GetComponent<BoxCollider>().size.x / 2;

        _RestPosition = _BackgroundPosition.x - _BackgroundWidth;


    }


    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * _BackgroundMovingspeed * Time.deltaTime);

        
        Debug.Log(_BackgroundWidth);
        Debug.Log(_RestPosition);

        if (transform.position.x <= _RestPosition)
        {
            this.transform.position = _BackgroundPosition;
        }
    }
}
