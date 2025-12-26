using TMPro;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    private int _PlayerScore;
    private TextMeshProUGUI _PlayerScoreBoard;
    void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        _PlayerScoreBoard = GetComponentInChildren<TextMeshProUGUI>();   
    }
  public void UpdateScoreBoard() 
  {
    {
        
        _PlayerScore = scoreManager.playerScore;
        string playerScore = $"SCORE \n {_PlayerScore}";
        _PlayerScoreBoard.text = playerScore;
    }

  }

}
