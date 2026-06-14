using Data;
using Interactables;
using Managers;
using UnityEngine;

public class Interactable_Pickup : Interactable
{
    [SerializeField] private EnumItemIds itemId;
    [SerializeField] private int quantity;

    public override void OnInteracted()
    {
        PlayerInventory pi = GetPlayerReference().GetComponent<PlayerInventory>();
        if (pi == null) return;
        InventoryStack stack = new InventoryStack();
        stack.ItemId = itemId;
        stack.Quantity = quantity;
        pi.AddItem(stack);
        Debug.LogWarning($"Stack added: {stack.ItemId}: {stack.Quantity}, inventory size: {pi._inventoryItems.Count}");
    }
}
