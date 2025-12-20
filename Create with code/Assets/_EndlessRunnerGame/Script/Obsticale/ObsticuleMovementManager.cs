using UnityEngine;

public class ObsticuleMovementManager : MonoBehaviour
{
    private Transform _obsticalTransfrom;

    
    private float _speed = 15f;

    public void ObsticuleSpeed(float speed)
    {
        _speed = speed;
    }
   

    void Awake()
    {
        _obsticalTransfrom = this.GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        _obsticalTransfrom.transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (_obsticalTransfrom.position.x < -5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
