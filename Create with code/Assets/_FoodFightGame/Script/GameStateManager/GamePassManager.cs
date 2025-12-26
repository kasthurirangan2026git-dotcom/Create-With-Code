using UnityEngine;

public class GamePassManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _PauseScreen;
    
    void Start()
    {
        _PauseScreen.SetActive(false);
    }

    public void GamePaused()
    {
        _PauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnGame()
    {
        _PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
