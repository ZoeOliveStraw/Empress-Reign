using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] public Button button;

    private SO_InventoryItem _inventoryItem;

    public void Initialize(InventoryStack itemStack)
    {
        _inventoryItem = ItemManager.Instance.GetItemFromID(itemStack.ItemId);
        icon.sprite = _inventoryItem.sprite;
        quantity.text = $"{itemStack.Quantity}";
    }
}
