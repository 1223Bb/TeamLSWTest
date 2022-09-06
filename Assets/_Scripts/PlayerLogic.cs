using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private PlayerMovement movement;
    private PlayerInteraction interaction;
    private bool canMove;

    private void Start()
    {
        GetReferences();
        SubscribeEvents();
        Initialization();
    }

    private void Update()
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
    }

    private void SubscribeEvents()
    {
        inputHandler.interact += Interact;
    }

    private void UnsubscribeEvents()
    {
        inputHandler.interact -= Interact;
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
        //Debug.Log("Player wants to interact");
        interaction.TryToInteract();
    }
}
