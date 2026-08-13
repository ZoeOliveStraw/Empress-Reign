using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryNPC : InventoryComponent
    {
        [SerializeField] private List<InventoryStack> items = new();
        
        public override bool InitializeInventory()
        {
            inventoryData = new InventoryData();
            if (inventoryData == null) return false;
            AddItemsToInventory();
            return true;
        }

        private void AddItemsToInventory()
        {
            foreach (var i in items)
            {
                inventoryData.AddItem(i.ItemId, i.Quantity);
            }
        }
    }
}