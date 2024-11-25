using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemDetails itemDetail;

    public ItemDetails ItemDetail
    {
        get { return itemDetail; }
        set { itemDetail = value; }
    }

    private SpriteRenderer theSR;

    private void Awake()
    {
        theSR = GetComponentInChildren<SpriteRenderer>();
        theSR.sprite = itemDetail.itemSprite;

        if (itemDetail.itemType == ItemType.Reapable)
        {
            gameObject.AddComponent<ItemNudge>();
        }
    }
}
