using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SO_InventoryEquipment", menuName = "Scriptable Objects/Inventory Items/Equipment")]
    public class SO_InventoryEquipment : SO_InventoryItem
    {
        public EnumEquipmentSlots equipmentSlot;
        //TODO: Add stat bonuses that can be attached to any equipment
    }
}
