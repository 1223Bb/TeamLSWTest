using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTracker : MonoBehaviour
{
    public static List<IInteractable> interactables;

    public void AddToList(IInteractable interactable)
    {
        if (!interactables.Contains(interactable))
        {
            interactables.Add(interactable);
        }
        else
        {
            Debug.LogWarning("Attempted to add an interactable that's already in the interactable list. Only call this function once, remove object before calling it again.");
        }
    }

    public void RemoveFromList(IInteractable interactable)
    {
        if(interactables.Contains(interactable))
        {
            interactables.Remove(interactable);
        }
        else
        {
            Debug.LogWarning("Attempted to remove an object that's not on the interactables list.");
        }
    }


}
