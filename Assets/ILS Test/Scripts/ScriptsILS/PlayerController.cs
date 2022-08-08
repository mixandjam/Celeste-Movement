using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{
    internal static event Action OnIsAnimJump;
    internal static event Action OnIsAnimIdle;
    internal static event Action OnIsAnimRun;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float playerRotate;

    [SerializeField] private float jumpSpeed;

    [SerializeField] private float dashSpeed = 20;

    [SerializeField] private bool isMovement = false;
    [SerializeField] private bool isSwim = false;

    [SerializeField] private bool checkGround = true;

    [SerializeField] Transform groundChecked;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Vector3 displacement;

    private void OnEnable()
    {
        CameraSwitch.OnRotatePlayer += RotatePlayer;
    }

    private void Update()
    {
        PlayerJump();
        PlayerDash();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        PlayerMove(horizontalMovement);

    }

    private void PlayerMove(float horizontalMovement)
    {
        displacement.Set(0f, 0f, horizontalMovement);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;

        transform.Translate(displacement);
       
        bool playerRun = horizontalMovement != 0f;

        if (playerRun)
        {
            isMovement = true;
            OnIsAnimRun?.Invoke();
        }
        else
        {
            isMovement = false;
            OnIsAnimIdle?.Invoke();
        }
    }
    
    private void PlayerJump()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnIsAnimJump?.Invoke();            
            rb.velocity = new Vector3(0f, jumpSpeed, 0f);            
        }        
    }
    private void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsMovement(true))
            {                
                var newVector = displacement.normalized * dashSpeed * Time.deltaTime;
                transform.Translate(newVector);                
            }
        }
    }

    private void RotatePlayer(Quaternion myRotation) => transform.rotation = myRotation;

    internal bool IsMovement(bool isActive)
    {
        isMovement = isActive;
        return isActive;
    }
    internal bool IsSwim(bool isActive)
    {
        isSwim = isActive;
        return isActive;
    }

    private void OnDisable()
    {
        CameraSwitch.OnRotatePlayer -= RotatePlayer;
    }
}
