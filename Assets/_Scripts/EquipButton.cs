using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour
{
    [SerializeField] private PlayerEquipment equipment;
    public void OnEquipButtonClick()
    {
        if(InventorySelectionTracker.Instance.selectedItem != null)
        {
            Debug.Log("Equipping " + InventorySelectionTracker.Instance.selectedItem.displayName);
            equipment.EquipItem(InventorySelectionTracker.Instance.selectedItem);
        }
        else
        {
            Debug.Log("No item to equip, unequipping everything");
            equipment.EquipItem(null);
        }
    }
}
