using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthInfoManager : MonoBehaviour
{
    [SerializeField]
    private Image _PlayerHealthBarOne;
    [SerializeField]
    private Image _PlayerHealthBarTwo;
    [SerializeField]
    private Image _PlayerHealthBarThree;

    public Image playerHealthBarOne
    {
        get
        {
            return _PlayerHealthBarOne;
        }
        set
        {
            _PlayerHealthBarOne = value;
        }
    }
   public Image playerHealthBarTwo
    {
        get
        {
            return _PlayerHealthBarTwo;
        }
        set
        {
            _PlayerHealthBarTwo = value;
        }
    }
    public Image playerHealthBarThree
    {
        get
        {
            return _PlayerHealthBarThree;
        }
        set
        {
            _PlayerHealthBarThree = value;
        }
    }
    private Color _RedColor = Color.darkRed;
    

    private FoodNinjaHealthManager foodNinjaHealthManager;
    [SerializeField]
    private GameObject _GameStateManager;

    void Awake()
    {
        foodNinjaHealthManager = _GameStateManager.GetComponent<FoodNinjaHealthManager>();
    }

    void Update()
    {
        if(foodNinjaHealthManager.playerHealth < 3)
            _PlayerHealthBarThree.color = _RedColor;
        if(foodNinjaHealthManager.playerHealth < 2)
            _PlayerHealthBarTwo.color = _RedColor;
        if(foodNinjaHealthManager.playerHealth <1)
            _PlayerHealthBarOne.color = _RedColor;
    }

}
