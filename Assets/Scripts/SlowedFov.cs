using System.Collections;
using UnityEngine;

public class SlowedFov : MonoBehaviour
{
    public Camera cam;
    public float decaySpeed;
    public bool isActive; 
    void Start()
    {
        cam = FindFirstObjectByType<Camera>();
    }

    void Update()
    {
        if (isActive)
        {
            cam.fieldOfView += decaySpeed;
        }
    }
    public void ResetFov()
    {
        cam.fieldOfView = 60;
    }
}
