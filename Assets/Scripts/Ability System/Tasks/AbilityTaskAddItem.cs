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
            if (myAbility.myParams.MyActor != null)
            {
                Inventory i = myAbility.myParams.MyActor.GetComponent<Inventory>();
                Debug.LogWarning($"Affected GameObject: {myAbility.myParams.MyActor.gameObject.name}");
                i.AddItem(itemId, amount);
            }
        }
    }
}
