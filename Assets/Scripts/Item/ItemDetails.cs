using UnityEngine;

public class ItemDetails : ScriptableObject
{
    public int itemCode;
    public ItemType itemType;
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool canPickedUp;
    public bool canBeDropped;
    public bool canBeCarried;
    public bool canBeConsumed;
}