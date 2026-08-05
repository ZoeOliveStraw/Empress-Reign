using Ability_System;
using UnityEngine;

public class AbilityTaskInteract : AbilityTask
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float interactionRange;

    protected override void Execute()
    {
        if (myAbility.myParams.TargetActor == null) return;
        AbilityParams newParams = new AbilityParams(
            targetActor: myAbility.myActor);
        myAbility.myParams.TargetActor.OnInteraction(newParams);
    }
}
