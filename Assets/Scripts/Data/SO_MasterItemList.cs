using System.Collections.Generic;
using Data;
using UnityEngine;

[CreateAssetMenu(fileName = "Master Item List", menuName = "Scriptable Objects/Master Item List")]
public class SO_MasterItemList : ScriptableObject
{
    [SerializeField] public List<SO_InventoryItem> InventoryItems = new List<SO_InventoryItem>(); 
}
