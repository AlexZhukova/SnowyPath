using UnityEngine;
using System;
    [Serializable]
public class InventoryItem
{
    public ItemData ItemData;

    public InventoryItem(ItemData itemData)
    {
        ItemData = itemData;
    }
}
