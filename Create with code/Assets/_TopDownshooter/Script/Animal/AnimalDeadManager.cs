using UnityEngine;

public class AnimalDeadManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public   void IsDead(GameObject gameObject)
    {
        Destroy(gameObject);
        audioSource.PlayOneShot(audioClip);
        
    }
}
