using UnityEngine;
using UnityEngine.UI;

public class MaleeHealthManager : MonoBehaviour
{
    private float _MaleeEnemyHealth = 100f;
    public float maleeEnemyHealth
    {
        get
        {
            return _MaleeEnemyHealth;
        }
        set
        {
            _MaleeEnemyHealth = value;
        }
    }
    private Slider _MaleehealthSlider;

    void Awake()
    {
        _MaleehealthSlider = GetComponentInChildren<Slider>();
    }
    void Update()
    {
        
        if(_MaleeEnemyHealth < 0)
        {
            Destroy(gameObject.transform.gameObject);
        }
    }
}
