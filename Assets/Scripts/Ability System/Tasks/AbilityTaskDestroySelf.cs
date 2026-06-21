using Ability_System;
using UnityEngine;

public class AbilityTaskDestroySelf : AbilityTask
{
    protected override void Execute()
    {
        base.Execute();
        GameObject myGO = myAbility.abilityOwner;
        if(myGO != null) Destroy(myGO);
    }
}
