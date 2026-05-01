using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryStack> _inventoryItems;
    
    void Start()
    {
        if(_inventoryItems == null) _inventoryItems = new List<InventoryStack>();
    }
    
    public void AddItem(InventoryStack item)
    {
        int quantity = item.Quantity;
        item.Quantity = 1;
        for(int i = 0; i < quantity; i++) AddItemSingle(item.ItemId);
    }

    private void AddItemSingle(EnumItemIds id)
    {
        SO_InventoryItem item = ItemManager.Instance.GetItemFromID(id);
        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            if (_inventoryItems[i].ItemId == id && _inventoryItems[i].Quantity < item.maxStackSize)
            {
                InventoryStack newStack = new InventoryStack();
                newStack.ItemId = id;
                newStack.Quantity = _inventoryItems[i].Quantity + 1;
                _inventoryItems[i] = newStack;
                return;
            }
        }
        InventoryStack newStack2 = new InventoryStack();
        newStack2.ItemId = id;
        newStack2.Quantity = 1;
        _inventoryItems.Add(newStack2);
    }

    public void RemoveItem(InventoryStack item, int quantity)
    {
        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            if (_inventoryItems[i].ItemId == item.ItemId)
            {
                
            }
        }
    }
}
