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
            if (myAbility.myParams.AffectedGameObject != null)
            {
                Inventory i = myAbility.myParams.AffectedGameObject.GetComponent<Inventory>();
                Debug.LogWarning($"Affected GameObject: {myAbility.myParams.AffectedGameObject.name}");
                i.AddItem(itemId, amount);
            }
        }
    }
}
