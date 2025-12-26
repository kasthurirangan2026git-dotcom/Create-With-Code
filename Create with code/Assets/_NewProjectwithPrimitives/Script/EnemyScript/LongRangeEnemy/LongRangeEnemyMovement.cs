using UnityEngine;

public class LongRangeEnemyMovement : MonoBehaviour
{
    private float _LongRangeEnemyMovementSpeed = 4.0f;
    private float _LongRangeEnemyZPositionLimit = 3f;
    private GameObject _Player;
    private bool _InAttackPostiton;
    public bool LongRangeInAttackPosition
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
       LongRangeEnemyMoveTowards();
    }

    void LongRangeEnemyMoveTowards()
    {
         if(transform.position.z >= _LongRangeEnemyZPositionLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Player.transform.position, _LongRangeEnemyMovementSpeed * Time.deltaTime);
        }
        else
        {
            _InAttackPostiton = true;
            return;
        }
    }
}

