using Ability_System;
using UnityEngine;

public class AbilityTaskDestroySelf : AbilityTask
{
    protected override void Execute()
    {
        base.Execute();
        GameObject myGO = myAbility.myActor.gameObject;
        if(myGO != null) Destroy(myGO);
    }
}
