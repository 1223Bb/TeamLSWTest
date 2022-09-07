using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GUIManager guiManager;
    [SerializeField] private CinemachineVirtualCamera inventoryCamera;
    private Inventory inventory;
    private bool isInventoryOpened = false;

    private void Start()
    {
        inventory = new Inventory();
        guiManager.SetPlayerInventory(inventory);
    }

    public void ToggleInventory()
    {
        guiManager.ToggleInventoryUI();
        isInventoryOpened = !isInventoryOpened;
        if(isInventoryOpened)
        {
            inventoryCamera.Priority = 11;
        }
        else
        {
            inventoryCamera.Priority = 9;
        }
    }
}
