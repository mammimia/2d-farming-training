using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Item/Seed")]
public class SeedItem : ItemDetails
{
    public SeedItem()
    {
        itemType = ItemType.Seed;
        itemUseGridRadius = 2;
        canPickedUp = true;
        canBeDropped = true;
        canBeCarried = true;
    }
}