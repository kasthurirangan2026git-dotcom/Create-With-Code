using System;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Camera _Camera1;
    [SerializeField]
    private Camera _Camera2;
   

    
    void Start()
    {
        _Camera1.enabled = true;
        _Camera2.enabled = false;
    }
    public void SwitchCameraView()
    { 
        _Camera1.enabled = !_Camera1.enabled;
        _Camera2.enabled = !_Camera2.enabled;
         
    }
}
