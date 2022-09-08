using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private InventoryItem itemInSlot;
    [SerializeField] TextMeshProUGUI txtValue;



    public void SetItem(InventoryItem item)
    {
        itemInSlot = item;
        SetIcon();
    }
    private void SetIcon()
    {
        icon.sprite = itemInSlot.icon;
        txtValue.text = itemInSlot.value.ToString();
    }

    public void SelectItem()
    {
        if(itemInSlot != null)
        {
            InventorySelectionTracker.Instance.SelectItem(itemInSlot);
        }
        else
        {
            InventorySelectionTracker.Instance.DeselectItem();
        }
    }
}
