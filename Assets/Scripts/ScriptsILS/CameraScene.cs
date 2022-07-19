using UnityEngine;
using Cinemachine;

public class CameraScene : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cinemaMachineVirtual;

    [SerializeField] private int index;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))              
        {
            index++;
            switch (index)
            {
                case 0:
                    CheckCineMachine(index);
                    break;
                case 1:
                    CheckCineMachine(index);
                    break;
                case 2:
                    CheckCineMachine(index);
                    break;
                case 3:
                    CheckCineMachine(index);
                    break;
            }
            if (index > 3)
            {
                index = 0;
            }
        }
    }

    private void CheckCineMachine(int index)
    {
        for (int i = 0; i < cinemaMachineVirtual.Length; i++)
        {
            cinemaMachineVirtual[i].enabled = false;   
        }
        cinemaMachineVirtual[index].enabled = true;
    }
}
