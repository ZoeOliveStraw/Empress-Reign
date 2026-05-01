using System;
using Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] public EquipmentSlots equipmentSlots;
        [SerializeField] private PlayerHands playerHands;

        private void Start()
        {
            if (equipmentSlots.RightHand != null) EquipRightHand(equipmentSlots.RightHand);
            if (equipmentSlots.LeftHand != null) EquipLeftHand(equipmentSlots.LeftHand);
            if (equipmentSlots.Amulet != null) EquipAmulet(equipmentSlots.Amulet);
            if (equipmentSlots.Accessory != null) EquipAccessory(equipmentSlots.Accessory);
            if (equipmentSlots.Helm != null) EquipHelm(equipmentSlots.Helm);
            if (equipmentSlots.Armor != null) EquipArmor(equipmentSlots.Armor);
            if (equipmentSlots.Boots != null) EquipBoots(equipmentSlots.Boots);
            if (equipmentSlots.Gloves != null) EquipGlove(equipmentSlots.Gloves);
        }

        public void EquipRightHand(SO_InventoryWeapon weapon)
        {
            equipmentSlots.RightHand = weapon;
            playerHands.EquipRightHandObject(weapon);
        }

        public void EquipLeftHand(SO_InventoryItem item)
        {
            equipmentSlots.LeftHand = item;
        }

        public void EquipAmulet(SO_InventoryItem item)
        {
            equipmentSlots.Amulet = item;
        }

        public void EquipAccessory(SO_InventoryItem item)
        {
            equipmentSlots.Accessory = item;
        }

        public void EquipHelm(SO_InventoryItem item)
        {
            equipmentSlots.Helm = item;
        }

        public void EquipArmor(SO_InventoryItem item)
        {
            equipmentSlots.Armor = item;
        }

        public void EquipBoots(SO_InventoryItem item)
        {
            equipmentSlots.Boots = item;
        }

        public void EquipGlove(SO_InventoryItem item)
        {
            equipmentSlots.Gloves = item;
        }
    }
}
