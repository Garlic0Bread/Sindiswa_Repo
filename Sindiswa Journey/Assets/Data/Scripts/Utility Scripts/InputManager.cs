using OWL;
using UnityEngine;
using System.Collections;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    
    private bool jumping_Input;
    private bool sprinting_Input;
    private bool inventory_Input;
    public GameObject inventoryPage;

    public bool D_Pad_Up;
    public bool D_Pad_Down;
    public bool D_Pad_Left;
    public bool D_Pad_Right;

    public float moveAmount;
    public float cameraInputX;
    public float cameraInputY;
    public float verticalInput;
    public float horizontalInput;

    AnimatorManager animManager;
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;

    [SerializeField] private Vector2 cameraInput;
    [SerializeField] private Vector2 movementInput;

    private void Awake()
    {
        animManager = GetComponentInChildren<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();//assigning the use of the Movement action of ActionMap PlayerMovement to vector2 movementInput
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();//assigning the use of the Camera action to vector2 cameraInput

            playerControls.PlayerActions.Shift.performed += i => sprinting_Input = true;
            playerControls.PlayerActions.Shift.canceled += i => sprinting_Input = false;

            playerControls.PlayerActions.Inventory.performed += i => inventory_Input = true; 
            playerControls.PlayerActions.Inventory.canceled += i => inventory_Input = false; 

            playerControls.PlayerActions.Jump.canceled += i => jumping_Input = true;
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleJumpInput();
        //HandleQuickSlot();
        //HandleAttackInput();
        HandleMovementInput();
        HandleSprintingInput();
        HandleInventoryInput();
    }

    private void HandleInventoryInput()
    {
        if (inventory_Input)
        {
            inventoryPage.SetActive(true);
            Inventory_Manager.Instance.List_Items_Into_Bag();
        }
    }
    private void HandleJumpInput()
    {
        if (jumping_Input)
        {
            jumping_Input = false;
            playerLocomotion.HandleJumping();
        }
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;//splitting the vector2(X,Y) movementInput to verticalMovement(Y) and horizontalMovement(X)
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }
    private void HandleSprintingInput()
    {
        if (sprinting_Input == true && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting= false;
        }
    }
    /*
    private void HandleAttackInput()
    {
        playerControls.PlayerActions.Attack.performed += i => HeavyMelee_1 = true;
        playerControls.PlayerActions.Attack.performed += i => LightMelee_1 = true;
        playerControls.PlayerActions.Attack.performed += i => LightMelee_2 = true;

        if (playerManager.joystickMoveVectror.y >= .1f)
        {
            playerAttacker.HandleLightMelee_1(playerInventory.current_MeleeWeapon);
        }

        if (playerManager.joystickMoveVectror.y >= .8f)
        {
            playerAttacker.HandleLightMelee_2(playerInventory.current_MeleeWeapon);
        }

        if (playerManager.joystickMoveVectror.y <= -.1f)
        {
            playerAttacker.HandleHeavyMelee_1(playerInventory.current_ShieldType);
        }
    }
    
    private void HandleQuickSlot()
    {
        playerControls.PlayerQuickSlots.DPadLeft.performed += i => D_Pad_Left = true;
        playerControls.PlayerQuickSlots.DPadRight.performed += i => D_Pad_Right = true;
        if (D_Pad_Left)
        {
            //playerInventory.Change_MeleeWeapon();
        }
        if (D_Pad_Right)
        {
            //playerInventory.Change_ShieldType();
        }
    }

    private void DPadLeft_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }*/
}
