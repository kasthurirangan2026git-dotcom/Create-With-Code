
using UnityEngine;

public class RangeEnemyMovement : MonoBehaviour
{
    
   
    private GameObject _Player;
    private int _RangeEnemyPositonZLimit = -1;
    private float _RangeEnemyMovementspeed = 7f;
    private bool _InAttackPostiton = false;
    private float _HorizontalMovementSpeed = 5f;
    public bool inAttackPostiton
    {
        get
        {
            return _InAttackPostiton;
        }
        set
        {
            _InAttackPostiton = value;
        }
    }



    void Awake()
    {
        if(GameObject.Find("Player").gameObject != null)
        {
            _Player = GameObject.Find("Player").gameObject;
        }

    }

    void Update()
    {
        
        RangeEnemymovingTowards();
        RangeEnemyMovingSideways();

    }






    void RangeEnemymovingTowards()
    {
        if(this.transform.position.z >= _RangeEnemyPositonZLimit && !_InAttackPostiton)
        {
            transform.position = Vector3.MoveTowards(transform.position,_Player.transform.position,_RangeEnemyMovementspeed * Time.deltaTime);

        }
        else
        {
            _InAttackPostiton = true;
            return;
        }

    }
    void RangeEnemyMovingSideways()
    {

       
        if (_InAttackPostiton)
        {
             transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,5,_RangeEnemyPositonZLimit),new Vector3(_Player.transform.position.x,5,_RangeEnemyPositonZLimit), _HorizontalMovementSpeed * Time.deltaTime);
             return;
        }
         
    }



}
