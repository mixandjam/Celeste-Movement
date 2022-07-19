using UnityEngine;

public class Swim : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerController.IsMovement(true))
            {
                playerController.IsMovement(false);
                playerController.IsSwim(true);

                if (playerController.IsSwim(true))
                {
                    //Anim.SetBool("isSwim", true)
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerController.IsSwim(true))
            {
                playerController.IsMovement(true);
                playerController.IsSwim(false);

                if (playerController.IsSwim(false))
                {
                    //Anim.SetBool("isSwim", false)
                }
            }
        }
    }
}
