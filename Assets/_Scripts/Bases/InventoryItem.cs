using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory item", menuName = "Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public InventoryItemType type;
    public int value;
}
