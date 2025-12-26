using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{ 
    private PlayerHealthanager playerHealthmanager;
    private GameOverManager gameOverManager;
    [SerializeField]
    private AudioClip audioClip;
    private AudioSource audioSource;
    bool Played = false;

    void Awake()
    {
        playerHealthmanager = FindAnyObjectByType<PlayerHealthanager>();
        gameOverManager  = FindAnyObjectByType<GameOverManager>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    { 
        if(playerHealthmanager.playerHealth == 0)
        {
            gameOverManager.IsGameOver();
            if(Played == false)
            {
                PlayOneTime(audioClip);
            }
        }           
    }
    void PlayOneTime(AudioClip audioClip)
    {
        Played = true;
        audioSource.PlayOneShot(audioClip);
    }     
}       

