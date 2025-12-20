using UnityEngine;

public class PlayerParticalEffectManager : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem PlayerDeadParticalEffectObject;
    [SerializeField]
    private ParticleSystem PlayerRunParticalEffectObject; 



    public void PlayerDeadParticalEffect()
    {
        PlayerDeadParticalEffectObject.Play();
    }
    public void PlayerRunParticalEffect(bool state)
    {
        if (state == true)
        {
            PlayerRunParticalEffectObject.Play();
        }
        else 
        { 
            PlayerRunParticalEffectObject.Stop();
        }
        
    }
}
