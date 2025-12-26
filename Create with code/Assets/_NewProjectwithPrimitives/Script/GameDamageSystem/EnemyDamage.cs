using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private const float _MaleeEnemyAttackDamage = 25;
    public float maleeEnemyAttackDamage
    {
        get
        {
            return _MaleeEnemyAttackDamage;
        }
    }
    private const float _RangeEnemyAttackDamage = 9;
    public float rangeEnemyAttackDamage
    {
        get
        {
            return _RangeEnemyAttackDamage;
        }
    }
    
    private const float _LongRangeEnemyAttackDamage = 12;
    public float longRangeEnemyAttackDamage
    {
        get
        {
            return _LongRangeEnemyAttackDamage;
        }
    }
}
