using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    public void SetItemDetails(ItemDetails itemDetails)
    {
        itemNameText.text = itemDetails.itemName;

        if (itemDetails.itemType == ItemType.Tool)
        {
            itemTypeText.text = "Tool - " + ((ToolItem)itemDetails).toolType;
        }
        else
        {
            itemTypeText.text = itemDetails.itemType.ToString();
        }

        itemDescriptionText.text = itemDetails.itemDescription;
    }
}
