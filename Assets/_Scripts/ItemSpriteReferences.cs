using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteReferences : MonoBehaviour
{
    public static ItemSpriteReferences Instance;
    public List<InventoryItem> items;
    public Dictionary<string, InventoryItem> itemDictionary = new Dictionary<string, InventoryItem>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        foreach(InventoryItem item in items)
        {
            itemDictionary.Add(item.displayName, item);
        }
    }
}
