using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    [SerializeField]
    private GameObject textScreen;
    [SerializeField]
    private GameObject player;
    

    void Start()
    {
        textScreen.SetActive(false);
    }

    public void IsGameOver()
    { 
      textScreen.SetActive(true);
      Destroy(player);
      
      
    }


}
