using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerController player;

    private Animator playerAnim;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        playerAnim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RunAnim();
    }
    void Update()
    {
        
    }

    void RunAnim()
    {
        if (player.playerMove)
        {
            playerAnim.SetBool("Run", true);
        }
        else
        {
            playerAnim.SetBool("Run", false);
        }
    }

}


