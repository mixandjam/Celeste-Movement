using Cinemachine;
using UnityEngine;
using System;

public class CameraSwitch : MonoBehaviour
{
    internal static event Action<Quaternion> OnRotatePlayer;

    [SerializeField] private CinemachineVirtualCamera[] cinemaMachineVirtual;

    [SerializeField] private int index;
    [SerializeField] private Quaternion myRotation;

    private void CheckCineMachine()
    {
        for (int i = 0; i < cinemaMachineVirtual.Length; i++)
        {
            cinemaMachineVirtual[i].enabled = false;
        }
        cinemaMachineVirtual[index].enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnRotatePlayer?.Invoke(myRotation);
            CheckCineMachine();
        }
    }
}
