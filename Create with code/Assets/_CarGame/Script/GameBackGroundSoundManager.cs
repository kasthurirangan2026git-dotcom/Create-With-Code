using UnityEngine;

public class GameBackGroundSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _SceneBackGroundMusic;
    [SerializeField]
    private AudioSource audioSource;



     private void Start()
    {
        if(audioSource.generator == null)
        {
            audioSource.generator = _SceneBackGroundMusic;
        }
        
        audioSource.volume = 0.5f;
        audioSource.playOnAwake = true;
        audioSource.Play(35);
    }
}
