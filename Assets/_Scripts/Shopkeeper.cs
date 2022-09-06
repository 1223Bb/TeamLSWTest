using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        Debug.Log("Toggle Shop menu");
    }
}
