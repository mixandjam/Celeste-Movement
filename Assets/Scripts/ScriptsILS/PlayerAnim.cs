using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnim : MonoBehaviour
{
    internal static event Action OnIsMovement;

    private PlayerController player;

    [SerializeField] internal Animator playerAnim;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();        
    }
    private void OnEnable()
    {
        PlayerController.OnIsAnimJump += JumpAnim;
        PlayerController.OnIsAnimIdle += IdleAnim;
        PlayerController.OnIsAnimRun += RunAnim;
    }
   
    private void IdleAnim() => playerAnim.SetBool("isRun", false);
    private void RunAnim() => playerAnim.SetBool("isRun", true);
    private void JumpAnim() => playerAnim.SetTrigger("isJump");

    private void OnDisable()
    {
        PlayerController.OnIsAnimJump -= JumpAnim;
        PlayerController.OnIsAnimIdle -= IdleAnim;
        PlayerController.OnIsAnimRun -= RunAnim;
    }

}


