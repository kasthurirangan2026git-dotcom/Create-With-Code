using UnityEngine;
using UnityEngine.UI;

public class AnimalHealthIndicator : MonoBehaviour
{
    [SerializeField]
   private Slider slider;

   private AnimalHealthManager animalHealthManager;

   private int animalHealthVaule;

   

    void Awake()
    { 
        slider = GetComponentInChildren<Slider>();
        animalHealthManager = this.GetComponent<AnimalHealthManager>();
    }

    void Update()
    {
        if(animalHealthManager != null)
        {
            if(animalHealthManager.animalHealth == 3)
            {
                slider.value = 1f;
            }
            if(animalHealthManager.animalHealth == 2)
            {
                slider.value = 0.5f;
            }
            if(animalHealthManager.animalHealth == 1)
            {
                slider.value = 0.2f;
            }
        }
    }
}
