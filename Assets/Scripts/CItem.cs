using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CItem : MonoBehaviour, Collectible
{
public static event HandleItemCollected OnCItemCollected;
public delegate void HandleItemCollected(ItemData itemData);
    public ItemData cdata;
    public void Collect()
    {
        Debug.Log("You collected a new item");
        Destroy(gameObject);
        OnCItemCollected?.Invoke(cdata);
    }
}
