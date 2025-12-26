using UnityEngine;

public class BottomSensorTriggerManager : MonoBehaviour
{
    private FoodNinjaHealthManager foodNinjaHealthManager;

    private int _PlayerHealthLossAmmount = 1;
    private const string _TargetBombTag = "TargetBomb";
    private const string _GameStateManagerGameObjectName = "GameStateManager";

    void Awake()
    {
        foodNinjaHealthManager = GameObject.Find(_GameStateManagerGameObjectName).GetComponent<FoodNinjaHealthManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(_TargetBombTag))
        {
            foodNinjaHealthManager.playerHealth -= _PlayerHealthLossAmmount;
        }
        Destroy(collision.gameObject);
        Debug.Log(foodNinjaHealthManager.playerHealth);
    }
}
