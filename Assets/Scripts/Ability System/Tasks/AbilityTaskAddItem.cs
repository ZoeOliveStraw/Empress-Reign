using DefaultNamespace;
using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskAddItem : AbilityTask
    {
        [SerializeField] private EnumItemIds itemId;
        [SerializeField] private int amount;
        
        protected override void Execute()
        {
            base.Execute();
            if (myAbility.myActor != null)
            {
                Debug.Log($"Adding {amount} of {ItemManager.Instance.GetItemFromID(itemId).itemName} to Inventory of {myAbility.myParams.TargetActor.name}");
                InventoryComponent data = myAbility.myParams.TargetActor.gameObject.GetComponent<InventoryComponent>();
                if (data == null)
                {
                    Debug.Log("No InventoryComponent, returning.");
                    return;
                }
                data.AddItemToInventory(itemId, amount);
            }
        }
    }
}
