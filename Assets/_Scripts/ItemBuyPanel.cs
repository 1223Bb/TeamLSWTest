using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemBuyPanel : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem itemOnDisplay;
    [SerializeField] private TextMeshProUGUI txtDisplayName, txtValue;
    [SerializeField] private Image icon;

    private Inventory inventory;

    private void Start()
    {
        SetDisplayInfo();
        inventory = playerInventory.GetInventory();
    }

    private void SetDisplayInfo()
    {
        icon.sprite = itemOnDisplay.icon;
        txtDisplayName.SetText(itemOnDisplay.displayName);
        txtValue.SetText(itemOnDisplay.value.ToString());
    }

    public void OnBuyButtonClick()
    {
        if(inventory.GetMoney() < itemOnDisplay.value)
        {
            Debug.Log("Player can't afford " + itemOnDisplay.displayName + ". Cost: " + itemOnDisplay.value + " | Player has: " + inventory.GetMoney());
        }
        else
        {
            inventory.AddItem(itemOnDisplay);
            inventory.SubtractMoney(itemOnDisplay.value);
            inventory.UpdateMoneyUI();
        }
    }

}
