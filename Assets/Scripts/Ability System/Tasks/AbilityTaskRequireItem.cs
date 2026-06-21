using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskRequireItem : AbilityTask
    {
        [SerializeField] private List<InventoryStack> requiredStacks;
        
        protected override void Execute()
        {
            base.Execute();
        }
    }
}
