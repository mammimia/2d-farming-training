using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Items/Item List")]
public class ItemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetails;
}
