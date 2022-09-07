using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<InventoryItem> items;
    private int slotCount;

    public Action onInventoryUpdate;

    public Inventory()
    {
        items = new List<InventoryItem>();
        AddItemToInventory(new InventoryItem { type = InventoryItemType.bluePants});   
    }

    public void AddItemToInventory(InventoryItem item)
    {
        items.Add(item);
        onInventoryUpdate?.Invoke();
    }

    public List<InventoryItem> GetItemList()
    {
        return items;
    }

}
