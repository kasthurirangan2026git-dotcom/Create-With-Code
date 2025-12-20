using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField]
   private GameObject PlayerBodyGameObject;
   private Animator _playerAnimetor;

    void Awake()
    {
        _playerAnimetor = PlayerBodyGameObject.GetComponent<Animator>();
    }

    public void  PlayerAnimation(string animationName)
    {
        _playerAnimetor.SetTrigger(animationName);
    }
}
