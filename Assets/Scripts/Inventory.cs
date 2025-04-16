using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using static Unity.Burst.Intrinsics.Arm;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private void OnEnable()
    {
        CItem.OnCItemCollected += Add;
    }
    private void OnDisable()
    {
        CItem.OnCItemCollected -= Add;
    }
    public void Add(ItemData itemData)

    {
        Debug.Log("You have collected new item");
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
    }
}