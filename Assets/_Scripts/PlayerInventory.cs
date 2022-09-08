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

    private void Awake()
    {
        inventory = new Inventory();
        inventory.AddItem(ItemSpriteReferences.Instance.itemDictionary["Red Shirt"]);
        inventory.AddItem(ItemSpriteReferences.Instance.itemDictionary["Blue Pants"]);
        guiManager.SetPlayerInventory(inventory);
        //Debug.Log("InvCount " + inventory.GetCount());
    }

    private void Start()
    {
        
        //guiManager.SetPlayerInventory(inventory);
    }

    public Inventory GetInventory()
    {
        return inventory;
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
