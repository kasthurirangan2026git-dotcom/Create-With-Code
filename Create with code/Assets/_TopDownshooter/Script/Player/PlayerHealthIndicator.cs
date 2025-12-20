
using UnityEngine;


public class PlayerHealthIndicator : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image[] healthIndicator;
    private Color Red = new Color (225,0,0);
    
  
  private PlayerHealthmanager healthmanager;


    void Awake()
    {
        healthmanager = FindAnyObjectByType<PlayerHealthmanager>();
        
    }

    void Update()
    {
        if(healthmanager.playerHealth == 2)
        {
            
            healthIndicator[2].color = Red;
        }
        if (healthmanager.playerHealth == 1)
        {
            healthIndicator[1].color = Red;
        }
        if(healthmanager.playerHealth == 0)
        {
            healthIndicator[0].color = Red;
        }
    }



}
