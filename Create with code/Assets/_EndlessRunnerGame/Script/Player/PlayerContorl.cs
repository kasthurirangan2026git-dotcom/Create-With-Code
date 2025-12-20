using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerContorl : MonoBehaviour
{
    private Rigidbody _PlayerRigitbody;
    Vector3 vector3 = new Vector3(0,170,0);
    private  PlayerCollision  playerState;
    private Vector3 _Gravity = new Vector3(0,-40,0f);
    [SerializeField]
    private GameObject GameOverManagerObject;
    private RunnerGamerOverManager runnerGamerOverManager;
    [SerializeField]
    private GameObject PlayerAnimationManagerObject;
    private PlayerAnimationManager playerAnimationManager;
    [SerializeField]
    private GameObject PlayerAudioMaangerObject;
    private PlayerAudioManager playerAudioManager;
    




    void Awake()
    {
        playerState = GetComponent<PlayerCollision>();
        runnerGamerOverManager = GameOverManagerObject.GetComponent<RunnerGamerOverManager>();
        playerAnimationManager = PlayerAnimationManagerObject.GetComponent<PlayerAnimationManager>();
        playerAudioManager = PlayerAudioMaangerObject.GetComponent<PlayerAudioManager>();
      
        


    }
    void Start()
    {
        _PlayerRigitbody = GetComponent<Rigidbody>();
        Physics.gravity = _Gravity;
        
    }


    void OnJump()
    { 
        if(playerState.isPlayerInGround && runnerGamerOverManager.GameIsrunning())
        {
            playerAnimationManager.PlayerAnimation("Jump_trig");
            PlayerJump(_PlayerRigitbody.linearVelocity.y == 0);
            return;
        }
  
    }

    void PlayerJump( bool isGround)
    {
        if(isGround)
        {
            _PlayerRigitbody.AddForce(vector3,ForceMode.Impulse);
            playerAudioManager.PlayJumpAudio();
            playerState.PlayerGroundState(false);
        }
    }

    void Update()
    {
        if (!runnerGamerOverManager.GameIsrunning())
        {
            playerAnimationManager.PlayerAnimation("Death_b");
        }
        
    }



}
