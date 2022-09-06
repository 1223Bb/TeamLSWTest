using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GUIManager guiManager;
    private int inventorySlots;

    public void ToggleInventory()
    {
        guiManager.ToggleInventoryUI();
    }
}
