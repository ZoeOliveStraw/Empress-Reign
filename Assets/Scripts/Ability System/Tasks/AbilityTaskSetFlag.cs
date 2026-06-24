using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskSetFlag : AbilityTask
    {
        [SerializeField] private EnumCharacterFlags flag;
        [SerializeField] private bool Value;
        
        protected override void Execute()
        {
            myAbility.myActor.Flags.SetFlag(flag, Value);
        }
    }
}