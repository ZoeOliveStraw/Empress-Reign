using Ability_System;
using UnityEngine;

public class AbilityTaskDamageTarget : AbilityTask
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;

    protected override void Execute()
    {
        base.Execute();
        myAbility.myParams.TargetGameObject.GetComponent<Health>().TakeDamage(damage);
    }
}
