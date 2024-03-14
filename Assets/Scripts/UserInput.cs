using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    //The script for handling the UserInput!
    //It takes a PlayerInput and converts the inputs to bools and Vector2s to make it easier to program other shit with.
    //Right now it only has interact and Move.
    //If you want more buttons, you can just do what I did for them
    



    // Start is called before the first frame update
    private PlayerInput _playerInput;

    public Vector2 MoveInput { get; private set; } //Input bool for Move

    public bool InteractJustPressed { get; private set; } 
    public bool InteractHeld { get; private set; }

    public bool InteractReleased { get; private set; }

    private InputAction _interactAction;
    private InputAction _moveAction;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        SetupInputActions();
    }

    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Move"];
        _interactAction = _playerInput.actions["Interact"];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        InteractJustPressed = _interactAction.WasPressedThisFrame();
        InteractHeld = _interactAction.IsPressed();
        InteractReleased = _interactAction.WasReleasedThisFrame();
    }
}
