using UnityEngine;
using UnityEngine.Assertions.Must;

public class Target : MonoBehaviour
{
    void Start()
    {
        gameObject.tag = "Target";
        Destroy(gameObject,3f);
        if(gameObject.name == "Skull(Clone)")
        {
            gameObject.name = "Skull";
        }
    }

    

}
