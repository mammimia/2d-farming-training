using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "Item/Crop")]
public class CropItem : ItemDetails
{
    public CropItem()
    {
        itemType = ItemType.Crop;
        itemUseGridRadius = 2;
        canPickedUp = true;
        canBeDropped = true;
        canBeCarried = true;
        canBeConsumed = true;
    }
}