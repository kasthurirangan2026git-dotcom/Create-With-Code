using UnityEngine;

public class RotateBlade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    float BladeSpeed = 2000f;

    void Update()
    {
        this.transform.Rotate(Vector3.forward*BladeSpeed*Time.deltaTime);
    }

}
