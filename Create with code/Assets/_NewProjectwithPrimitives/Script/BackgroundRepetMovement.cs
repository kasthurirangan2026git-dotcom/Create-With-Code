using UnityEngine;

public class BackgroundRepetMovement : MonoBehaviour
{
   
   private float _BackgroundColliderZSize;
   private Vector3 _StartingPosition;
   private float _BackgroundMovingSpeed = 2f; 
    void Start()
    {   transform.position = Vector3.zero;
        _StartingPosition = this.transform.position;
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back* _BackgroundMovingSpeed * Time.deltaTime);
        if(this.transform.position.z <= -50)
        {
            transform.position = _StartingPosition;
        }
    }
}
