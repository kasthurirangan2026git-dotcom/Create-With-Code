using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip JumpAudioClip;
    [SerializeField]
    private AudioClip DeadAudioClip;
    [SerializeField]
    private AudioSource audioSource;


    public void PlayJumpAudio()
    {
        audioSource.PlayOneShot(JumpAudioClip);
    }

    public void PlayDeadAudioClip()
    {
        audioSource.PlayOneShot(DeadAudioClip);
    }
}
