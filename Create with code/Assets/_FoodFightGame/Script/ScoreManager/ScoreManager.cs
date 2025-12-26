using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   private int _PlayerScore = 0;
   public int playerScore
    {
        get
        {
            return _PlayerScore;
        }
        set
        {
            _PlayerScore = value;
        }
    }
    public void UpdatePlayerScore(int score)
    {
        _PlayerScore += score;
    }

    
}
