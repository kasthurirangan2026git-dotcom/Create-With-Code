using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject _MainMenuUI;
    [SerializeField]
    private GameObject _PlayerHealthInfoUI;
    [SerializeField]
    private GameObject _PlayerScoreInfoUI;
    [SerializeField]
    private GameObject _GameStateManager;
    private GameStateManager gameStateManager;
    private TargetSpawnManager targetSpwanManager;
    private const string SpawnManagerObject = "SpawnManager";
    private const int _Easy = 3;
    private const int _Normal = 2;
    private const int _Hard = 1;
    [SerializeField]
    private GameObject _PauseButton;
    void Awake()
    {
        gameStateManager = _GameStateManager.GetComponent<GameStateManager>();
        targetSpwanManager = GameObject.Find(SpawnManagerObject).GetComponent<TargetSpawnManager>();
    }
    void Start()
    {
        _MainMenuUI.SetActive(true);
        _PlayerHealthInfoUI.SetActive(false);
        _PlayerScoreInfoUI.SetActive(false);
    }
    public void EasyMode()
    {
        targetSpwanManager.difficultyValue = _Easy;
        ScreenTransition();
    }
    public void NormalMode()
    {   
        targetSpwanManager.difficultyValue = _Normal;
        ScreenTransition();
    }
    public void HardMode()
    {
        targetSpwanManager.difficultyValue = _Hard;
        ScreenTransition();
    }




    private void ScreenTransition()
    {
        _MainMenuUI.SetActive(false);
        _PlayerHealthInfoUI.SetActive(true);
        _PlayerScoreInfoUI.SetActive(true);
        _PauseButton.SetActive(true);
        gameStateManager.isGameStart = true;
    }
}
