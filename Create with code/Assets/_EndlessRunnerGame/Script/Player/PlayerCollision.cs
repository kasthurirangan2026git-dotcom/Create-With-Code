using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   
    public bool isPlayerInGround {get;set;}

    public bool PlayerGroundState(bool state)
    {
       return isPlayerInGround =  state;
    }

    [SerializeField]
    private GameObject gameoverManagerObject;
    private RunnerGamerOverManager gameOverManager;

    [SerializeField]
    private GameObject PlayerParticalEffectManagerObject;
    private PlayerParticalEffectManager playerParticalEffectManager;

    void Awake()
    {
        gameOverManager = gameoverManagerObject.GetComponent<RunnerGamerOverManager>();
        playerParticalEffectManager = PlayerParticalEffectManagerObject.GetComponent<PlayerParticalEffectManager>();
    }






    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerInGround = true;

            playerParticalEffectManager.PlayerRunParticalEffect(true);  
        }

        if (collision.gameObject.CompareTag("Obsticle"))
        {
            gameOverManager.GameOver(collision.gameObject);
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerParticalEffectManager.PlayerRunParticalEffect(false); 
        }
    }


}
