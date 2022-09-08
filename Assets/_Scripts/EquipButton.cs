using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour
{
    public void OnEquipButtonClick()
    {
        if(InventorySelectionTracker.Instance.selectedItem != null)
        {
            Debug.Log("Equipping " + InventorySelectionTracker.Instance.selectedItem.displayName);
        }
        else
        {
            Debug.Log("No item to equip");
        }
    }
}
