using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    private Inventory playerItemInventory;

    private void Start()
    {
        playerItemInventory = playerInventory.GetInventory();
    }
    public void OnSellButtonClick()
    {
        if(InventorySelectionTracker.Instance.selectedItem != null)
        {
            Debug.Log("Selling " + InventorySelectionTracker.Instance.selectedItem.displayName + " for " + InventorySelectionTracker.Instance.selectedItem.value + " gold.");
            playerItemInventory.GiveMoney(InventorySelectionTracker.Instance.selectedItem.value);
            playerItemInventory.RemoveItem(InventorySelectionTracker.Instance.selectedItem);
            playerItemInventory.UpdateMoneyUI();
            //GUIManager.Instance.RefreshPlayerInventory();
            InventorySelectionTracker.Instance.DeselectItem();
        }
        else
        {
            Debug.Log("Can't sell, player didn't select any item");
        }
    }
}
