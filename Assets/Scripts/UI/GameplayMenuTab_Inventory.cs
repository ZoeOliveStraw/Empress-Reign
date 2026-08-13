using System.Collections.Generic;
using Data;
using Managers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class GameplayMenuTab_Inventory : GameplayMenuTab
    {
        [SerializeField] private GameObject prefabInventoryItem;
        [SerializeField] private GameObject prefabEquipmentItem;
        [SerializeField] private Transform inventoryDisplayContent;

        private InventoryData playerInventoryData;
        
        private List<UI_InventoryItem> inventoryItemIcons;

        private void GetPlayerInventory()
        {
            playerInventoryData = PlayerManager.Instance.PlayerInventoryData;
        }

        private void InitializeInventory()
        {
            if (playerInventoryData == null) GetPlayerInventory();

            if (inventoryItemIcons == null)
            {
                inventoryItemIcons = new List<UI_InventoryItem>();
            }
            
            if (playerInventoryData != null)
            {
                RenderInventory();
            }
        }

        public void OnEnable()
        {
            InitializeInventory();
        }

        private void RenderInventory()
        {
            ClearInventory();
            PopulateInventory();
        }

        private void ClearInventory()
        {
            foreach (UI_InventoryItem obj in inventoryItemIcons) 
            {
                Destroy(obj.gameObject);
            }
            inventoryItemIcons.Clear();
        }

        private void PopulateInventory()
        {
            List<InventoryStack> data = PlayerManager.Instance.PlayerInventoryData._inventoryItems;
            Debug.Log($"Inventory stack numbers: {data.Count}");
            for (int i = 0; i < data.Count; i++)
            {
                AddItemIcon(data[i], i);
            }
        }

        private void AddItemIcon(InventoryStack stack, int index)
        {
            UI_InventoryItem inventoryItem = Instantiate(prefabInventoryItem, inventoryDisplayContent).GetComponent<UI_InventoryItem>();
            inventoryItem.Initialize(stack);
            inventoryItem.button.onClick.AddListener(() => RemoveItemAtIndex(index));
            inventoryItemIcons.Add(inventoryItem);
        }

        private void RemoveItemAtIndex(int index, int quantity = 1)
        {
            //TODO: write the method lol
        }
    }
}
