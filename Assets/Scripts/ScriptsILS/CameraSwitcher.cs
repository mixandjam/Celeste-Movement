using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static void Register (CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera registered : " + camera);
    }
       
    public static void Unregister (CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera unregistered : " + camera);
    }
}
