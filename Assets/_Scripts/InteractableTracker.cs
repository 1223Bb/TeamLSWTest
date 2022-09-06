using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTracker : MonoBehaviour
{
    //Singleton
    public static InteractableTracker tracker;

    public static List<GameObject> activeInteractables = new List<GameObject>();

    private void Awake()
    {
        if(tracker==null)
        {
            tracker = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void AddToList(GameObject interactable)
    {
        if (!activeInteractables.Contains(interactable))
        {
            activeInteractables.Add(interactable);
        }
        else
        {
            Debug.LogWarning("Attempted to add an interactable that's already in the interactable list. Only call this function once, remove object before calling it again.");
        }
    }

    public void RemoveFromList(GameObject interactable)
    {
        if(activeInteractables.Contains(interactable))
        {
            activeInteractables.Remove(interactable);
        }
        else
        {
            Debug.LogWarning("Attempted to remove an object that's not on the interactables list.");
        }
    }
}
