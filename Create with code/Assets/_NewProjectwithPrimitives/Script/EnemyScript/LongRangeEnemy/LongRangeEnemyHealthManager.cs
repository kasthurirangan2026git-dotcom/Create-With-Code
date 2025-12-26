using UnityEngine;
using UnityEngine.UI;

public class LongRangeEnemyHealthManager : MonoBehaviour
{
   private float _LongRangeEnemyHealth = 100f;
   public float longRangeEnemyHealth
    {
        get
        {
            return _LongRangeEnemyHealth;
        }
        set
        {
            _LongRangeEnemyHealth = value;
        }
    } 
   private Slider _LongRangeEnemyHealthSlider;
   
   
    void Start()
    {
        _LongRangeEnemyHealthSlider = GetComponentInChildren<Slider>();
    }
    void Update()
    {
        _LongRangeEnemyHealthSlider.value = _LongRangeEnemyHealth / 100;
        if(_LongRangeEnemyHealth <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
