using UnityEngine;

[CreateAssetMenu(fileName = "Stump", menuName = "Item/Stump")]
public class StumpItem : ItemDetails
{
    public StumpItem()
    {
        itemType = ItemType.Seed;
    }
}