using Data;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public SO_MasterItemList masterItemList;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public SO_InventoryItem GetItemFromID(EnumItemIds itemId)
    {
        foreach (var item in masterItemList.InventoryItems)
        {
            if (item.itemId == itemId) return item;
        }
        return null;
    }
}
