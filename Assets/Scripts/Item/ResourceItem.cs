using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Item/Resource")]
public class ResourceItem : ItemDetails
{
    public ResourceItem()
    {
        itemType = ItemType.Resource;
        itemUseGridRadius = 2;
        canPickedUp = true;
        canBeDropped = true;
        canBeCarried = true;
    }
}