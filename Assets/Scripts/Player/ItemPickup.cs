using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (!item || !item.ItemDetail.canPickedUp) return;

        InventoryManager.Instance.addItem(item.ItemDetail);
        Destroy(item.gameObject);
    }
}
