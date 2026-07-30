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

        private List<UI_InventoryItem> inventoryItemIcons;
        //private PlayerInventory inventory;

        public void Start()
        {
            InitializeInventory();
        }

        private void InitializeInventory()
        {
            /*if (inventory == null)
            {
                inventory = LevelManager.Instance.GetPlayer().GetComponent<PlayerInventory>();
            }

            if (inventoryItemIcons == null)
            {
                inventoryItemIcons = new List<UI_InventoryItem>();
            }
            
            if (inventory != null)
            {
                RenderInventory();
            }*/
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
            /*for (int i = 0; i < inventory._inventoryItems.Count; i++)
            {
                AddItemIcon(inventory._inventoryItems[i], i);
            }*/
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
