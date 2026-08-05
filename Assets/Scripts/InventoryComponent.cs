using Data;
using UnityEngine;

public abstract class InventoryComponent : MonoBehaviour
{
    public abstract bool InitializeInventory();
    public abstract void AddItemToInventory(InventoryStack item);
    public abstract void RemoveItems();
    public abstract int GetItemCount(EnumItemIds id);
}
