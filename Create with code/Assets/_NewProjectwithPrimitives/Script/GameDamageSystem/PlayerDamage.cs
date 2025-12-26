using UnityEngine;

public class PlayerAttackDamageManager : MonoBehaviour
{
    
    public float playerAttackDamageAmmount
    {
        get
        {
            return  Random.Range(5,9);
        }
    }
}
