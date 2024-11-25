using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehavior<InventoryManager>
{
    private Dictionary<int, InventoryItem> inventory = new Dictionary<int, InventoryItem>();

    private int currentInventorySize;

    private void Start()
    {
        currentInventorySize = Settings.initialInventorySize;
    }

    public void addItem(ItemDetails itemDetails)
    {
        if (inventory.Count >= currentInventorySize)
        {
            // Inventory is full
            Debug.Log("Inventory is full");
            return;
        }

        if (inventory.ContainsKey(itemDetails.itemCode))
        {
            // Item already exists in inventory, so increase quantity
            inventory[itemDetails.itemCode].itemQuantity += 1;
        }
        else
        {
            // Item doesn't exist in inventory, so add it
            inventory.Add(itemDetails.itemCode, new InventoryItem(itemDetails, 1));
        }
    }
}

public class InventoryItem
{
    public ItemDetails itemDetails;
    public int itemQuantity;

    public InventoryItem(ItemDetails itemDetails, int itemQuantity)
    {
        this.itemDetails = itemDetails;
        this.itemQuantity = itemQuantity;
    }
}
