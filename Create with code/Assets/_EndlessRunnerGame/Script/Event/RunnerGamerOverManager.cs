using UnityEngine;

public class RunnerGamerOverManager : MonoBehaviour
{
    private ObsticuleMovementManager obsticuleMovementManager;
    [SerializeField]
    private GameObject backgroundObject;
    private BackgroundMoving backgroundMoving;
    [SerializeField]
    private GameObject SpawnManagerObject;
    private ObsticalSpawnmanager obsticalSpawnmanager;
    [SerializeField]
    private GameObject PlayerParticalEffect;
    private PlayerParticalEffectManager playerParticalEffectManager;

    [SerializeField]
    private GameObject PlayerAudioMaangerObject;
    private PlayerAudioManager playerAudioManager;

    private bool _GameIsrunning;

    public bool GameIsrunning()
    {
         return _GameIsrunning;
    }
    


    

    void Awake()
    {
        backgroundMoving = backgroundObject.GetComponent<BackgroundMoving>();

        obsticalSpawnmanager = SpawnManagerObject.GetComponent<ObsticalSpawnmanager>();

        _GameIsrunning = true;

        playerParticalEffectManager = PlayerParticalEffect.GetComponent<PlayerParticalEffectManager>();

        playerAudioManager = PlayerAudioMaangerObject.GetComponent<PlayerAudioManager>();
    }




    public void GameOver(GameObject gameObject)
   {
         obsticuleMovementManager = gameObject.gameObject.GetComponent<ObsticuleMovementManager>();
         obsticuleMovementManager.ObsticuleSpeed(0);
         backgroundMoving.BackgroundMovingspeedContorl(0);
         obsticalSpawnmanager.StopInvoking("ObsticalSpawn");
         _GameIsrunning = false;
         playerParticalEffectManager.PlayerDeadParticalEffect();
         playerParticalEffectManager.PlayerRunParticalEffect(false);
         playerAudioManager.PlayDeadAudioClip();
        

   }

}
