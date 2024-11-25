using UnityEngine;

[CreateAssetMenu(fileName = "Furniture", menuName = "Item/Furniture")]
public class FurnitureItem : ItemDetails
{
    public FurnitureItem()
    {
        itemType = ItemType.Furniture;
    }
}