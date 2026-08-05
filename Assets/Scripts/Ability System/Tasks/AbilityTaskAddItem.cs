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
                /*Inventory i = myAbility.myActor.GetComponent<Inventory>();
                Debug.LogWarning($"Affected GameObject: {myAbility.myActor.gameObject.name}");
                i.AddItem(itemId, amount);*/
            }
        }
    }
}
