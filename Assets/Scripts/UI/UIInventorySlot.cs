using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;
    private Transform parentItem;
    private GameObject draggedItem;

    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI inventorySlotText;

    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemQuantity;
    [SerializeField] private GameObject itemPrefab;

    private void Start()
    {
        mainCamera = Camera.main;
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParent).transform;
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
}
