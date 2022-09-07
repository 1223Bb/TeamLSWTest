using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string id, displayName;
    public int goldValue, amount, maxAmount;
    public InventoryItemType type;
    public Sprite icon;

    public Sprite GetSprite()
    {
        switch(type)
        {
            default:
            case InventoryItemType.redShirt:    return ItemAssets.Instance.redShirt;
            case InventoryItemType.greenShirt:  return ItemAssets.Instance.greenShirt;
            case InventoryItemType.blueShirt:   return ItemAssets.Instance.blueShirt;
            case InventoryItemType.redPants:    return ItemAssets.Instance.redPants;
            case InventoryItemType.greenPants:  return ItemAssets.Instance.greenPants;
            case InventoryItemType.bluePants:   return ItemAssets.Instance.bluePants;
            case InventoryItemType.redShoes:    return ItemAssets.Instance.redShoes;
            case InventoryItemType.tanShoes:    return ItemAssets.Instance.tanShoes;
            case InventoryItemType.blackShoes:  return ItemAssets.Instance.blackShoes;
        }
    }
}
