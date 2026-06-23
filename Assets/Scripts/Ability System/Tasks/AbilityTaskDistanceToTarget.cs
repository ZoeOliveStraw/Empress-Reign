using Ability_System;
using UnityEngine;
using UnityEngine.LowLevelPhysics2D;

public class AbilityTaskDistanceToTarget : AbilityTask
{
    [SerializeField] private float distanceToTarget;
    [SerializeField] private bool minimum;

    public override bool CanExecuteTask()
    {
        var distance = Vector3.Distance(myAbility.myParams.TargetActor.transform.position, myAbility.myActor.transform.position);
        if(minimum) return distance > distanceToTarget; 
        return distance <= distanceToTarget;
    }
}
