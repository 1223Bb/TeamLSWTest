using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 movementIntent;
    public Action interact;
    public Action inventory;
    private void OnEnable()
    {
        EnableControls();
        EventSubscription();
    }

    private void OnDisable()
    {
        EventUnsubscription();
        DisableControls();
    }

    private void EventSubscription()
    {
        playerControls.Default.Movement.performed += MovementInputHandle;
        playerControls.Default.Movement.canceled += MovementInputHandle;
        playerControls.Default.Interaction.performed += Interact;
        playerControls.Default.Inventory.performed += Inventory;
    }

    private void EventUnsubscription()
    {
        playerControls.Default.Movement.performed -= MovementInputHandle;
        playerControls.Default.Movement.canceled -= MovementInputHandle;
        playerControls.Default.Interaction.performed -= Interact;
        playerControls.Default.Inventory.performed -= Inventory;
    }
    private void MovementInputHandle(InputAction.CallbackContext obj)
    {
        movementIntent = obj.ReadValue<Vector2>();
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        interact?.Invoke();
    }

    private void Inventory(InputAction.CallbackContext obj)
    {
        inventory?.Invoke();
    }

    private void EnableControls()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }

    private void DisableControls()
    {
        playerControls.Disable();
    }

    public Vector2 GetMovementIntent()
    {
        return movementIntent;
    }
}
