using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    [SerializeField] private float playerRotate;

    [SerializeField] public bool playerMove = false;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 displacement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        PlayerMove(horizontalMovement);
    }

    void Update()
    {
        
    }

    void PlayerMove (float horizontalMovement)
    {
        displacement.Set(0f, 0f, horizontalMovement);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + displacement);

        if (horizontalMovement != 0f)
        {
            PlayerRotate(horizontalMovement);
        }

        bool playerRun = horizontalMovement != 0f;

        if (playerRun)
        {
            playerMove = true;
        }
        else
        {
            playerMove = false;
        }
    }

    void PlayerRotate(float horizontalMovement)
    {
        float interpolation = playerRotate * Time.deltaTime;
        Vector3 targetDirection = new Vector3(0f, 0f, horizontalMovement);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, interpolation);
        rb.MoveRotation(newRotation);


    }


}
