using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;
    //describtions?

    public void ClearSlot()
    {
        if (icon != null)
            icon.enabled = false;

        if (labelText != null)
            labelText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        labelText.enabled = true;

        icon.sprite = item.ItemData.icon;
        labelText.text = item.ItemData.displayName;
        //labelText.text = item.ItemData.description; // Assuming you want to show the description
    }
}
