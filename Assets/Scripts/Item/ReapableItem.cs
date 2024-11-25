using UnityEngine;

[CreateAssetMenu(fileName = "Reapable", menuName = "Item/Reapable")]
public class ReapableItem : ItemDetails
{
    public ReapableItem()
    {
        itemType = ItemType.Reapable;
    }
}