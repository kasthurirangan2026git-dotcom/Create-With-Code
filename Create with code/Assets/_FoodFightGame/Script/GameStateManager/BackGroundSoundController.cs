using UnityEngine;
using UnityEngine.UI;

public class BackGroundSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip _BackGroundSound;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Slider _VolumeSlider;
    private float _SliderValue;
    public static BackGroundSoundController backGroundSoundController;
    private const float _InitialValue = 0.2f;
    void Awake()
    {
        if(backGroundSoundController != null)
        {
            Destroy(gameObject);
            return;  
        } 
        backGroundSoundController = this;
        DontDestroyOnLoad(backGroundSoundController);

    }
  

    void Start()
    {
        audioSource.generator = _BackGroundSound;
        audioSource.playOnAwake = true;
        audioSource.loop =  true;
        _VolumeSlider.value = _InitialValue;
        audioSource.Play();
        InvokeRepeating("AudioPlay",0f,0.2f);
    }
      void AudioPlay()
    {
        _SliderValue = _VolumeSlider.value;
        
        audioSource.volume = _SliderValue;
    } 
}
