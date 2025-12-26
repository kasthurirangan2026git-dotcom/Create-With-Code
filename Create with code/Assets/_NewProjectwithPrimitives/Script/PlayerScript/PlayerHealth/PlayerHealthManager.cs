using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    private  float _PlayerHealth = 100f;
    [SerializeField]
    private Slider _PlayerHealthIndicator;

    public float playerHealth
    {
        get
        {
            return _PlayerHealth;
        }
        set
        {
            _PlayerHealth = value;
        }
    }
    void Start()
    {
        _PlayerHealthIndicator.value = 1f;
    }
    void Update()
    {
        _PlayerHealthIndicator.value = _PlayerHealth / 100;
        if(_PlayerHealth > 100)
        {
            _PlayerHealth = 100;
        }
        
    }
}
