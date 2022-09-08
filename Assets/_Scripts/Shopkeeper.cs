using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private GUIManager guiManager;

    private void OnEnable()
    {
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
        guiManager.ToggleShopInventoryUI();
    }
}
