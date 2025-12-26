using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class RangeEnemyHealthManager : MonoBehaviour
{
    
    private Slider _RangeEnemySlider;
    private GameObject _RangeEnemy;
    
   

   public float _RangeEnemyHealth = 100;
    public float RangeEnemyHealth
    {
        get
        {
           return _RangeEnemyHealth;
        }
        set
        {
            _RangeEnemyHealth = value;
        }
    }
     void Awake()
    {
        _RangeEnemySlider = GetComponentInChildren<Slider>();
        _RangeEnemy = transform.parent.gameObject;
    }
    void Update()
    {
        _RangeEnemySlider.value = _RangeEnemyHealth / 100;
        if(_RangeEnemyHealth <= 0)
        {
            Destroy(_RangeEnemy.gameObject);
        }
    }


}
