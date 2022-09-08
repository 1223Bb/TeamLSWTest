using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> items = new List<InventoryItem>();
    private int money;

    private void Start()
    {
        UpdateMoneyUI();
    }

    public void UpdateMoneyUI()
    {
        GUIManager.Instance.SetGoldAmmount(money);
    }

    public void AddItem(InventoryItem itemToAdd)
    {
        items.Add(itemToAdd);
        Debug.Log(itemToAdd.displayName + "has been added. Item count is now at " + items.Count);
        GUIManager.Instance.RefreshPlayerInventory();
    }

    public void RemoveItem(InventoryItem itemToRemove)
    {
        items.Remove(itemToRemove);
        Debug.Log(itemToRemove.displayName + "has been removed. Item count is now at " + items.Count);
        GUIManager.Instance.RefreshPlayerInventory();
    }

    public List<InventoryItem> GetItemList()
    {
        return items;
    }

    public int GetCount()
    {
        return items.Count;
    }

    public void GiveMoney(int amount)
    {
        money += amount;
    }

    public void SetMoney(int amount)
    {
        money = amount;
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
        //Should never happen, but in case it does.
        if(money<0)
        {
            money = 0;
        }
    }
    //private List<InventoryItem> items;
    //private int slotCount;

    //public Action onInventoryUpdate;

    //public Inventory()
    //{
    //    items = new List<InventoryItem>();
    //    AddItemToInventory(new InventoryItem { type = InventoryItemType.bluePants});   
    //}

    //public void AddItemToInventory(InventoryItem item)
    //{
    //    items.Add(item);
    //    onInventoryUpdate?.Invoke();
    //}

    //public List<InventoryItem> GetItemList()
    //{
    //    return items;
    //}

}
