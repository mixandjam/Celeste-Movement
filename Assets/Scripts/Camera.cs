using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera frontCamera;
    [SerializeField] CinemachineVirtualCamera rightCamera;
    [SerializeField] CinemachineVirtualCamera backCamera;
    [SerializeField] CinemachineVirtualCamera leftCamera;

    private void OnEnable()
    {
        CameraSwitcher.Register(frontCamera);
        CameraSwitcher.Register(rightCamera);
        CameraSwitcher.Register(backCamera);
        CameraSwitcher.Register(leftCamera);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(frontCamera);
        CameraSwitcher.Unregister(rightCamera);
        CameraSwitcher.Unregister(backCamera);
        CameraSwitcher.Unregister(leftCamera);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Switch Camera
        }
    }
}
