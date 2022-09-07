using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private PlayerMovement movement;
    private PlayerInteraction interaction;
    private PlayerInventory inventory;
    private bool canMove = true;
    private bool canInteract = true;
    private bool hasInventoryOpen = false;

    private void Start()
    {
        GetReferences();
        SubscribeEvents();
        Initialization();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Initialization()
    {
        canMove = true;
    }

    private void GetReferences()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
        interaction = GetComponent<PlayerInteraction>();
        inventory = GetComponent<PlayerInventory>();
    }

    private void SubscribeEvents()
    {
        inputHandler.interact += Interact;
        inputHandler.inventory += ToggleInventory;
    }

    private void UnsubscribeEvents()
    {
        inputHandler.interact -= Interact;
        inputHandler.inventory -= ToggleInventory;
    }

    private void Movement()
    {
        if(canMove)
        {
            movement.MovePlayer(inputHandler.GetMovementIntent());
        }
    }

    private void Interact()
    {
        if(canInteract)
        {
            interaction.TryToInteract();
        }
    }

    private void ToggleInventory()
    {
        Debug.Log("Player toggled inventory");
        hasInventoryOpen = !hasInventoryOpen;
        canInteract = !canInteract;
        canMove = !canMove;
        inventory.ToggleInventory();
    }
}
