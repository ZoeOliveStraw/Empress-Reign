using System;
using Data;
using UnityEngine;

public abstract class InventoryComponent : MonoBehaviour
{
    protected InventoryData inventoryData;

    private void Start()
    {
        InitializeInventory();
    }

    public abstract bool InitializeInventory();

    public virtual bool HasItem(EnumItemIds id, int quantity)
    {
        return inventoryData.HasItem(id, quantity);
    }

    public virtual void AddItemToInventory(EnumItemIds itemId, int quantity = 1)
    {
        Debug.Log("AddItemToInventory called");
        Debug.Log($"inventoryData null: {inventoryData == null}");
        inventoryData.AddItem(itemId, quantity);
    }

    public virtual int GetItemCount(EnumItemIds id)
    {
        return inventoryData.GetQuantity(id);
    }
}
