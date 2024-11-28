using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Camera mainCamera;
    private Canvas parentCanvas;
    private Transform parentItem;
    private GameObject draggedItem;

    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI inventorySlotText;

    [SerializeField] public int slotNumber;
    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemQuantity;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject itemDetailsTextBoxPrefab;

    private void Awake()
    {
        parentCanvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParent).transform;
        slotNumber = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails == null) return;

        Player.Instance.disablePlayerInput();
        // Debug transform.position
        draggedItem = Instantiate(UIInventoryBar.Instance.draggedItem, UIInventoryBar.Instance.transform);
        draggedItem.GetComponentInChildren<Image>().sprite = inventorySlotImage.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem == null) return;

        draggedItem.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem == null) return;

        Destroy(draggedItem);
        bool isDraggedToInventoryBar = eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null;

        if (isDraggedToInventoryBar)
        {
            int targetSlotNumber = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>().slotNumber;
            InventoryManager.Instance.swapInventoryItems(slotNumber, targetSlotNumber);
        }
        else
        {
            if (itemDetails.canBeDropped)
            {
                dropItemAtMousePosition();
            }
        }

        Player.Instance.enablePlayerInput();
    }

    private void dropItemAtMousePosition()
    {
        if (itemDetails == null) return;

        Vector3 newPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

        GameObject itemGameObject = Instantiate(itemPrefab, newPosition, Quaternion.identity, parentItem);
        Item item = itemGameObject.GetComponent<Item>();
        item.ItemDetail = itemDetails;

        InventoryManager.Instance.removeItem(itemDetails);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemDetails == null) return;

        UIInventoryBar.Instance.itemDetailsTextBoxGameObject = Instantiate(itemDetailsTextBoxPrefab, transform.position, Quaternion.identity);
        UIInventoryBar.Instance.itemDetailsTextBoxGameObject.transform.SetParent(parentCanvas.transform, false);

        UIInventoryTextBox inventoryTextBox = UIInventoryBar.Instance.itemDetailsTextBoxGameObject.GetComponent<UIInventoryTextBox>();
        inventoryTextBox.SetItemDetails(itemDetails);

        if (UIInventoryBar.Instance.isInventoryBarOnTop)
        {
            UIInventoryBar.Instance.itemDetailsTextBoxGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
            UIInventoryBar.Instance.itemDetailsTextBoxGameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 150f, transform.position.z);
        }
        else
        {
            UIInventoryBar.Instance.itemDetailsTextBoxGameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            UIInventoryBar.Instance.itemDetailsTextBoxGameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 150f, transform.position.z);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (UIInventoryBar.Instance.itemDetailsTextBoxGameObject != null)
        {
            Destroy(UIInventoryBar.Instance.itemDetailsTextBoxGameObject);
        }
    }
}
