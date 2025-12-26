using UnityEngine;

public class GameStateManager : MonoBehaviour
{
   private FoodNinjaGameOverManager foodNinjaGameOverManager;
   private FoodNinjaHealthManager foodNinjaHealthManager;
   private const string _PlayerHealthManagerGameObjectName = "GameStateManager";
   private bool _IsGameStart;
   public bool isGameStart
    {
        get
        {
            return _IsGameStart;
        }
        set
        {
            _IsGameStart = value;
        }
    }
     private bool _IsGameActive;
   public bool isGameActive
    {
        get
        {
            return _IsGameActive;
        }
        set
        {
            _IsGameActive = value;
        }
    }

    void Awake()
    {
        foodNinjaGameOverManager = GetComponent<FoodNinjaGameOverManager>();
        
        foodNinjaHealthManager = GetComponent<FoodNinjaHealthManager>();
    }
    void Update()
    {
        if(foodNinjaHealthManager.playerHealth < 1)
        {
            _IsGameStart = false;
            foodNinjaGameOverManager.GameOver();
            
        }
    }
}
