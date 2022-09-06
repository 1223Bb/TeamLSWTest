using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    private void OnEnable()
    {
        Debug.Log("Is singleton missing?:" + (InteractableTracker.tracker == null));
        AddToActiveInteractableList();
    }

    private void OnDisable()
    {
        RemoveFromActiveInteractableList();
    }
    private void AddToActiveInteractableList()
    { 
        InteractableTracker.tracker.AddToList(gameObject);
    }

    private void RemoveFromActiveInteractableList()
    {
        InteractableTracker.tracker.RemoveFromList(gameObject);
    }

    public void Interaction()
    {
        Debug.Log("Toggle Shop menu");
    }
}
