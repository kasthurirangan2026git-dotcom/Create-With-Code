using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MaleeChargeAttckManager : MonoBehaviour
{
   private MaleeEnemyMovement maleeEnemyMovement;
   private bool _IsTimerAvailable = true;
   private Slider _MaleeChargeslider;
   private float _CharingTime = 0;
    void Awake()
    {
        maleeEnemyMovement = GetComponentInParent<MaleeEnemyMovement>();
        
    }
    void Start()
    {
        _MaleeChargeslider = GetComponentInChildren<Slider>();
    }
    void Update()
    {
        if (maleeEnemyMovement.isReadyToAttack&& _IsTimerAvailable)
        {
            _IsTimerAvailable = false;
            StartCoroutine(SlamPrebtime());
                 
            
        
        }
    }
        IEnumerator SlamPrebtime()
    {
        _CharingTime = maleeEnemyMovement.slamAttackChargeTime;
        float  SlamTimer  = 0;
        while(SlamTimer < _CharingTime)
        {
            SlamTimer += Time.smoothDeltaTime;
            
           float sliderValue = SlamTimer/maleeEnemyMovement.slamAttackChargeTime;
           
            _MaleeChargeslider.value = sliderValue;
            yield return null;
        }
    }
}
