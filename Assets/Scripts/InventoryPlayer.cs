using Data;

namespace DefaultNamespace
{
    public class InventoryPlayer : InventoryComponent
    {
        public override bool InitializeInventory()
        {
            return true;
        }

        public override void AddItemToInventory(InventoryStack item)
        {
            
        }

        public override void RemoveItems()
        {
            
        }

        public override int GetItemCount(EnumItemIds id)
        {
            return 0;
        }
    }
}