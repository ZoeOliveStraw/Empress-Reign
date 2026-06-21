namespace Data
{
    public struct InventoryStack
    {
        public EnumItemIds ItemId;
        public int Quantity;

        public InventoryStack(EnumItemIds itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
