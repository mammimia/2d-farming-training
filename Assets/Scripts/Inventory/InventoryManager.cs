using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehavior<InventoryManager>
{
    private Dictionary<int, InventoryItem> inventory = new Dictionary<int, InventoryItem>();

    private int currentInventorySize;

    private int selectedItemSlot = -1;

    private void Start()
    {
        currentInventorySize = Settings.initialInventorySize;
    }

    public List<InventoryItem> GetInventoryList()
    {
        List<InventoryItem> inventoryList = new List<InventoryItem>();
        foreach (KeyValuePair<int, InventoryItem> inventoryItem in inventory)
        {
            inventoryList.Add(inventoryItem.Value);
        }

        return inventoryList;
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
            int position = inventory.Count;
            inventory.Add(itemDetails.itemCode, new InventoryItem(itemDetails, 1, position));
        }

        EventHandler.CallInventoryUpdateEvent();
    }

    public void removeItem(ItemDetails itemDetails)
    {
        if (inventory.ContainsKey(itemDetails.itemCode))
        {
            inventory[itemDetails.itemCode].itemQuantity -= 1;

            if (inventory[itemDetails.itemCode].itemQuantity <= 0)
            {
                inventory.Remove(itemDetails.itemCode);
                UIInventoryBar.Instance.clearSlotHighlights();
            }
            EventHandler.CallInventoryUpdateEvent();
        }
    }

    public void swapInventoryItems(int sourceSlotNumber, int destinationSlotNumber)
    {
        InventoryItem sourceInventoryItem = getInventoryItemInSlot(sourceSlotNumber);
        InventoryItem destinationInventoryItem = getInventoryItemInSlot(destinationSlotNumber);

        if (sourceInventoryItem != null) sourceInventoryItem.position = destinationSlotNumber;
        if (destinationInventoryItem != null) destinationInventoryItem.position = sourceSlotNumber;

        EventHandler.CallInventoryUpdateEvent();
    }

    public InventoryItem getInventoryItemInSlot(int slotNumber)
    {
        foreach (KeyValuePair<int, InventoryItem> inventoryItem in inventory)
        {
            if (inventoryItem.Value.position == slotNumber)
            {
                return inventoryItem.Value;
            }
        }

        return null;
    }

    public void selectItemSlot(int slotNumber)
    {
        selectedItemSlot = slotNumber;
    }

    public void clearSelectedItem()
    {
        selectedItemSlot = -1;
    }
}

public class InventoryItem
{
    public ItemDetails itemDetails;
    public int itemQuantity;
    public int position;

    public InventoryItem(ItemDetails itemDetails, int itemQuantity, int position)
    {
        this.itemDetails = itemDetails;
        this.itemQuantity = itemQuantity;
        this.position = position;
    }
}
