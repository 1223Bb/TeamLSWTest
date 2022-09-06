using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    private InteractableTracker interactableTracker;

    private void OnEnable()
    {
        AddToActiveInteractableList();
    }

    private void OnDisable()
    {
        RemoveFromActiveInteractableList();
    }

    public void Interaction()
    {
        Debug.Log("Toggle Shop menu");
    }

    private void AddToActiveInteractableList()
    {
        interactableTracker.AddToList(this);
    }

    private void RemoveFromActiveInteractableList()
    {
        interactableTracker.AddToList(this);
    }
}
