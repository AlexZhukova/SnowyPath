using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChanged;

    public List<InventoryItem> inventory = new List<InventoryItem>(6);

    private void OnEnable()
    {
        CItem.OnCItemCollected += Add;
    }

    public void Add(ItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogWarning("Attempted to add a null item to the inventory.");
            return;
        }

        // Check for duplicates (optional, based on requirements)
        if (inventory.Exists(item => item.ItemData == itemData))
        {
            Debug.Log("Item already exists in the inventory.");
            return;
        }

        Debug.Log("You have collected a new item.");
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);

        OnInventoryChanged?.Invoke(inventory);

    }
}
