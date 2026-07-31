using Data;
using UnityEngine;

public class ItemManager : MonoBehaviour, IManagerProperties
{
    public static ItemManager Instance;
    public SO_MasterItemList masterItemList;
    
    private bool isLoaded;
    public bool IsLoaded => isLoaded;
    public  void SetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        isLoaded = true;
    }
    
    private void Awake()
    {
        SetInstance();
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
