using UnityEngine;

public class FoodNinjaHealthManager : MonoBehaviour
{
    private int _PlayerHealth = 3;
   public int playerHealth
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
}
