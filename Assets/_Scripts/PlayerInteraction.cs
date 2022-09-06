using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float maxRange = 5;

    public void TryToInteract()
    {
        //List of active interactables
        List<GameObject> activeInteractables = InteractableTracker.activeInteractables;
        //Item to interact with
        GameObject closestInteractable = null;
        //Check for distance with every item inside if there are any.
        //If there are, interact
        if(activeInteractables != null)
        {
        foreach(GameObject item in activeInteractables)
        {
            float distanceToItem = Vector2.Distance(this.transform.position, item.transform.position);
            if (distanceToItem <= maxRange)
            {
                if (closestInteractable == null)
                {
                    closestInteractable = item;
                }
                else if (distanceToItem < Vector2.Distance(this.transform.position, closestInteractable.transform.position))
                {
                    closestInteractable = item;
                }
            }
        }
        if(closestInteractable == null)
            {
                Debug.Log("There are interactables, just not near the player");
            }
            else
            {
                closestInteractable.GetComponent<IInteractable>().Interaction();
            }
        }
        else
        {
            Debug.Log("Can't interact, no interactables are active");
        }
    }
}
