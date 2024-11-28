using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : SingletonMonoBehavior<UIInventoryBar>
{
    [SerializeField] private Sprite blank16x16Sprite;
    [SerializeField] private UIInventorySlot[] inventorySlots;
    public GameObject draggedItem;

    private RectTransform rectTransform;
    private bool _isInventoryBarOnTop = true;

    [HideInInspector] public GameObject itemDetailsTextBoxGameObject;

    public bool isInventoryBarOnTop
    {
        get => _isInventoryBarOnTop;
        set => _isInventoryBarOnTop = value;
    }

    protected override void Awake()
    {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        switchInventoryBarPosition();
    }

    private void OnEnable()
    {
        EventHandler.inventoryUpdateEvent += itemAddedToInventory;
    }

    private void OnDisable()
    {
        EventHandler.inventoryUpdateEvent -= itemAddedToInventory;
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
            InventoryItem inventoryItem = InventoryManager.Instance.getInventoryItemInSlot(i);
            if (inventoryItem != null)
            {
                inventorySlots[i].inventorySlotImage.sprite = inventoryItem.itemDetails.itemSprite;
                inventorySlots[i].inventorySlotText.text = inventoryItem.itemQuantity.ToString();
                inventorySlots[i].itemDetails = inventoryItem.itemDetails;
                inventorySlots[i].itemQuantity = inventoryItem.itemQuantity;
            }
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
