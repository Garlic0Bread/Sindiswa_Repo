using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input fields
    private ThirdPersonActionsController playerActionsAsset;
    private InputAction move;
    private InputAction sprint;

    // Movement fields
    private Rigidbody rb;

    [SerializeField]
    private float movementForce = 1f;

    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private float maxSpeed = 5f;

    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float rotSpeed;

    [SerializeField]
    private float sprintSpeed;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonActionsController();
    }

    private void OnEnable()
    {
        playerActionsAsset.Player.Jump.started += DoJump;
        move = playerActionsAsset.Player.Move;
        sprint = playerActionsAsset.Player.Sprint;
        playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAsset.Player.Jump.started -= DoJump;
        playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        // Adjust movement force based on sprint input
        float currentMovementForce = movementForce;
        if (sprint.ReadValue<float>() > 0)
        {
            currentMovementForce = sprintSpeed;
        }

        forceDirection += moveInput.x * GetCameraRight(playerCamera) * currentMovementForce;
        forceDirection += moveInput.y * GetCameraForward(playerCamera) * currentMovementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0f;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        if (moveInput != Vector2.zero)
        {
            Vector3 targetDirection = GetCameraForward(playerCamera);
            targetDirection.y = 0f; // Ensure we only rotate along the Y axis
            if (targetDirection != Vector3.zero) // Ensure there's a direction to look at
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.fixedDeltaTime * rotSpeed);
            }
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
}
