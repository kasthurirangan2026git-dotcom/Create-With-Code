using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodNinjaGameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _GameOverUI;

    public void GameOver()
    {
        
        _GameOverUI.SetActive(true);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
