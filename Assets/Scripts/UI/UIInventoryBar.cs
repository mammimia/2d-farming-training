using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField] private Sprite blank16x16Sprite;
    [SerializeField] private UIInventorySlot[] inventorySlots;

    private RectTransform rectTransform;
    private bool _isInventoryBarOnTop = true;

    private bool isInventoryBarOnTop
    {
        get => _isInventoryBarOnTop;
        set => _isInventoryBarOnTop = value;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        switchInventoryBarPosition();
    }

    private void OnEnable()
    {
        EventHandler.itemAddedToInventoryEvent += itemAddedToInventory;
    }

    private void OnDisable()
    {
        EventHandler.itemAddedToInventoryEvent -= itemAddedToInventory;
    }

    private void switchInventoryBarPosition()
    {
        Vector3 playerViewportPosition = Player.Instance.getPlayerViewportPosition();

        if (playerViewportPosition.y > 0.3f && !isInventoryBarOnTop)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0);
            rectTransform.anchorMax = new Vector2(0.5f, 0);
            rectTransform.pivot = new Vector2(0.5f, 0);
            rectTransform.anchoredPosition = new Vector2(0, 2.5f);

            isInventoryBarOnTop = true;
        }
        else if (playerViewportPosition.y <= 0.3f && isInventoryBarOnTop)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 1);
            rectTransform.anchorMax = new Vector2(0.5f, 1);
            rectTransform.pivot = new Vector2(0.5f, 1);
            rectTransform.anchoredPosition = new Vector2(0, -2.5f);

            isInventoryBarOnTop = false;
        }
    }

    private void itemAddedToInventory(List<InventoryItem> inventoryItems)
    {
        clearInventorySlots();

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i >= inventoryItems.Count)
            {
                break;
            }

            inventorySlots[i].inventorySlotImage.sprite = inventoryItems[i].itemDetails.itemSprite;
            inventorySlots[i].inventorySlotText.text = inventoryItems[i].itemQuantity.ToString();
            inventorySlots[i].itemDetails = inventoryItems[i].itemDetails;
            inventorySlots[i].itemQuantity = inventoryItems[i].itemQuantity;
        }
    }

    private void clearInventorySlots()
    {
        foreach (UIInventorySlot inventorySlot in inventorySlots)
        {
            inventorySlot.inventorySlotImage.sprite = blank16x16Sprite;
            inventorySlot.inventorySlotText.text = "";
            inventorySlot.itemDetails = null;
        }
    }
}
