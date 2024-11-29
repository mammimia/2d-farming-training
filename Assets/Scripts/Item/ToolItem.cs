using UnityEngine;


[CreateAssetMenu(fileName = "Tool", menuName = "Item/Tool")]
public class ToolItem : ItemDetails
{
    public ToolType toolType;

    public ToolItem()
    {
        itemType = ItemType.Tool;
        itemUseGridRadius = 1;
        canPickedUp = true;
    }
}