using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
   
    private GameManagerX gameManagerX;
    private float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    public void EasyDifficulty()
    {
        difficulty = 1.5f;
        gameManagerX.StartGame(difficulty);
    }
    public void NormalDifficulty()
    {
        difficulty = 0.8f;
        gameManagerX.StartGame(difficulty);
    }
    public void HardDifficulty()
    {
        difficulty = 0.5f;
        gameManagerX.StartGame(difficulty);
    }



}
