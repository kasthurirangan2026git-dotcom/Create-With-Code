
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class TargetMouseDetiction : MonoBehaviour
{
    private string playerScoreManagerGameObjectName = "PlayerScoreInfo";

    private const string _TargetCommon = "TargetCommon";
    private const string _TargetRare = "TargetRare";
    private const string _TargetEpic = "TargetEpic";
    private const string _TargetBomb = "TargetBomb";

    private const int _TargetCommonPoint = 5;
    private const int _TargetRarePoint = 10;
    private const int _TargetEpicPoint = 20;
    
    private string _TargetGameObjectTagName;
    public string targetGameObjectTagName
    {
        get
        {
            return _TargetGameObjectTagName;
        }
    }
    
    private Camera _Camera;
    private ScoreManager scoreManager;
    private ScoreBoardManager scoreBoardManager;
    [SerializeField]
    private List<GameObject> _TargetParticalEffectOnDestroy;
    [SerializeField]
    private ParticleSystem _BlackPartical;


    void Awake()
    {
        _Camera = Camera.main;
        
        scoreManager = GameObject.Find(playerScoreManagerGameObjectName).GetComponent<ScoreManager>();
        scoreBoardManager = GameObject.Find(playerScoreManagerGameObjectName).GetComponent<ScoreBoardManager>();
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _Camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            _TargetGameObjectTagName = hit.collider.gameObject.tag;
            GameObject targetGameObject = hit.collider.gameObject;
            
            
            switch (_TargetGameObjectTagName)
            {
                case _TargetCommon:
                    scoreManager.UpdatePlayerScore(_TargetCommonPoint);
                    Instantiate(_TargetParticalEffectOnDestroy[0],targetGameObject.transform.position,targetGameObject.transform.rotation);
                    Destroy(targetGameObject);
                break;

                case _TargetRare:
                    scoreManager.UpdatePlayerScore(_TargetRarePoint);
                    Instantiate(_TargetParticalEffectOnDestroy[1],targetGameObject.transform.position,targetGameObject.transform.rotation);
                    Destroy(targetGameObject);
                break;

                case _TargetEpic:
                    scoreManager.UpdatePlayerScore(_TargetEpicPoint);
                    Instantiate(_TargetParticalEffectOnDestroy[2],targetGameObject.transform.position,targetGameObject.transform.rotation);
                    Destroy(targetGameObject);
                break;

                case _TargetBomb: 
                    scoreManager.UpdatePlayerScore(Random.Range(-10,-20));
                    Instantiate(_TargetParticalEffectOnDestroy[3],targetGameObject.transform.position,targetGameObject.transform.rotation);
                    Destroy(targetGameObject);
                break;
            }

            scoreBoardManager.UpdateScoreBoard();

        }


        
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            _BlackPartical.gameObject.SetActive(true);
           Vector2 MousePos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            _BlackPartical.transform.position = MousePos;
            return;
        }
        _BlackPartical.gameObject.SetActive(false);
        return;
       
        

    }
}




