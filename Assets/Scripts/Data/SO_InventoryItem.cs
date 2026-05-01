using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Inventory Items/Item")]
    public class  SO_InventoryItem : ScriptableObject
    {
        [Header("Item Info")]
        [SerializeField] public EnumItemIds itemId;
        [SerializeField] public string itemName;
        [SerializeField] public string description;
        [SerializeField] public Sprite sprite;
        [SerializeField] public int value;
        [SerializeField] public int maxStackSize = 1;
    } 
}
