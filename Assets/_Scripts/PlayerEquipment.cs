using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private InventoryItem shirt, bottom, shoes;
    [SerializeField] private GameObject redShirt, bluePants, tanShoes;



    public void EquipItem(InventoryItem itemToEquip)
    {
        if (itemToEquip == null)
        {
            UnequipItems();
        }
        else
        {
            switch(itemToEquip.type)
            {
                default:
                    Debug.Log("Non Equippable Item");
                break;
                case (InventoryItemType.torso):
                    shirt = itemToEquip;
                break;
                case (InventoryItemType.bottom):
                    bottom = itemToEquip;
                break;
                case (InventoryItemType.shoes):
                    shoes = itemToEquip;
                break;
            }
        }
        RefreshClothing();
    }

    private void UnequipItems()
    {
        shirt = null;
        bottom = null;
        shoes = null;
    }

    private void RefreshClothing()
    {
        if (shirt == null)
        {
            redShirt.SetActive(false);
        }
        else
        {
            redShirt.SetActive(true);
        }
        if (bottom == null)
        {
            bluePants.SetActive(false);
        }
        else
        {
            bluePants.SetActive(true);
        }
        if (shoes == null)
        {
            tanShoes.SetActive(false);
        }
        else
        {
            tanShoes.SetActive(true);
        }

    }

}
