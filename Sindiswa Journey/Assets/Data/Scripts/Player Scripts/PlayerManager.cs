using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    CameraManager camManager;
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    public bool isInteracting;
    public int noOfClicks = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        camManager = FindObjectOfType<CameraManager>();
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void LateUpdate()
    {
        camManager.HandleAllCameraMovements();
        if (isInteracting)
        {
            animator.GetBool("isInteracting");
            playerLocomotion.isJumping = animator.GetBool("isJumping");
            animator.SetBool("isGrounded", playerLocomotion.isGrounded);
        }
        inputManager.D_Pad_Left = false;
        inputManager.D_Pad_Right = false;
        inputManager.D_Pad_Down = false;
        inputManager.D_Pad_Up = false;
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
