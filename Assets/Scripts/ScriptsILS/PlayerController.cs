using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    [SerializeField] private float playerRotate;

    [SerializeField] private float jumpSpeed;

    [SerializeField] public bool playerMove = false;

    [SerializeField] public bool checkGround = true;

    [SerializeField] Transform groundChecked;

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
        PlayerJump();
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

    void PlayerJump()
    {
        Vector3 downfloor = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        if (Input.GetButton("Jump") && checkGround)
        {
            rb.velocity = new Vector3(0f, jumpSpeed, 0f);
            checkGround = false;
        }
        if (Physics.Raycast(groundChecked.position, downfloor, out hit, 0.2f) && hit.collider.CompareTag("Ground"))
        {
            checkGround = true;
        }
        else
        {
            checkGround = false;
        }

    }


}
