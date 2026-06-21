using System;
using System.Collections.Generic;
using UnityEngine;
using Data;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxSlots;
    
    private List<InventoryStack> _inventoryItems;
    
    private void Start()
    {
        _inventoryItems = new List<InventoryStack>();
    }

    public virtual bool HasItem(EnumItemIds itemId, int quantity = 1)
    {
        foreach (InventoryStack i in _inventoryItems)
        {
            if (i.ItemId == itemId)
            {
                int currentQuantity = GetQuantity(itemId);
                if (currentQuantity >= quantity) return true;
            }
        }
        return false;
    }

    public virtual void AddItem(EnumItemIds itemId, int quantity = 1)
    {
        if(ItemManager.Instance == null) return;
        SO_InventoryItem item = ItemManager.Instance.GetItemFromID(itemId);
        for (int i = 0; i < quantity; i++)
        {
            AddItemSingle(itemId, item);
        }
    }

    private void AddItemSingle(EnumItemIds itemId, SO_InventoryItem item)
    {
        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            if (_inventoryItems[i].ItemId == itemId && _inventoryItems[i].Quantity < item.maxStackSize)
            {
                InventoryStack newStack = new InventoryStack(_inventoryItems[i].ItemId, _inventoryItems[i].Quantity + 1);
                _inventoryItems[i] = newStack;
                return;
            }
        }
        InventoryStack newStack2 = new InventoryStack(itemId, 1);
        _inventoryItems.Add(newStack2);
    }

    public virtual int GetQuantity(EnumItemIds itemId)
    {
        int quantity = 0;
        foreach (InventoryStack i in _inventoryItems)
        {
            if (i.ItemId == itemId)
            {
                quantity += i.Quantity;
            }
        }
        return quantity;
    }
}
