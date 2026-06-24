using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskRequireFlagTrue : AbilityTask
    {
        [SerializeField] private EnumCharacterFlags flag;
        
        public override bool CanExecuteTask()
        {
            return myAbility.myActor.Flags.GetFlag(flag);
        }
    }
}