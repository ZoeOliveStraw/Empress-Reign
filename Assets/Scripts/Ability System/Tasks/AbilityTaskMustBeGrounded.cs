using Ability_System;
using Managers;
using UnityEngine;

public class AbilityTaskMustBeGrounded : AbilityTask
{
    [SerializeField] private GroundCheck groundCheck;

    public override bool CanExecuteTask()
    {
        return myAbility.myActor.Flags.GetFlag(EnumCharacterFlags.Grounded);
    }
}
