
using UnityEngine;


public class PlayerHealthIndicator : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image[] healthIndicator;
    private Color Red = new Color (225,0,0);
    
  
  private PlayerHealthanager healthmanager;


    void Awake()
    {
        healthmanager = FindAnyObjectByType<PlayerHealthanager>();
        
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
