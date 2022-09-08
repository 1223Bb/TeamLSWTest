using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelectionTracker : MonoBehaviour
{
    public static InventorySelectionTracker Instance;
    public InventoryItem selectedItem;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SelectItem(InventoryItem item)
    {
        selectedItem = item;
        Debug.Log("Selected an item (" + item + ")");
    }

    public void DeselectItem()
    {
        selectedItem = null;
        Debug.Log("Deselected an item");
    }
}
