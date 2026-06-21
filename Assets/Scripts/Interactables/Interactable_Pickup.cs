using Data;
using Interactables;
using Managers;
using UnityEngine;

public class Interactable_Pickup : Interactable
{
    [SerializeField] private EnumItemIds itemId;
    [SerializeField] private int quantity;

    public override void OnInteracted()
    {
        
    }
}
