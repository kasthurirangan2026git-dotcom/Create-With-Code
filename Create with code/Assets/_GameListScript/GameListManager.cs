using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameListManager : MonoBehaviour
{
    static GameListManager gameListManager;
    [SerializeField]
    private Canvas _GameListManagerCanvas;
    [SerializeField]
    private Canvas _GameListManagerOnScreenCanvas;
    void Awake()
    {
        if(gameListManager != null)
        {
            Destroy(gameObject);
            return;
        }
        gameListManager = this;
        DontDestroyOnLoad(gameListManager);

        _GameListManagerCanvas.gameObject.SetActive(false);
        _GameListManagerOnScreenCanvas.gameObject.SetActive(true);
    }

    public void CarGame()
    {
        LoadScene(0);
    }
    public void Aviator()
    {
        LoadScene(1);
    }
    public void CreateWithPrimative()
    {
        LoadScene(2);
    }
    public void AnimalStamped()
    {
        LoadScene(3);
    }
    public void EndlessRunner()
    {
        LoadScene(4);
    }
    public void BallFight()
    {
        LoadScene(5);
    }
    public  void NinjaFoodFight()
    {
        LoadScene(6);
    }
    public void WhankAFood()
    {
        LoadScene(7);
    }
    public void ScocooerGame()
    {
        LoadScene(8);
    }
    public void BalloonGame()
    {
        LoadScene(9);
    }
    public void DogFetchGame()
    {
        LoadScene(10);
    }

    private void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        _GameListManagerCanvas.gameObject.SetActive(false);
        _GameListManagerOnScreenCanvas.gameObject.SetActive(true);
    }

    public void OpenGameListManu()
    {
        _GameListManagerCanvas.gameObject.SetActive(true);
        _GameListManagerOnScreenCanvas.gameObject.SetActive(false);
    }
}
