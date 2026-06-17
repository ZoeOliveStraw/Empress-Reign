using Ability_System;
using UnityEngine;

public class AbilityTaskDamageTarget : AbilityTask
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;

    public override void Execute()
    {
        Debug.LogWarning("TakeDamage executed!");
        base.Execute();
        myAbility.myParams.TargetGameObject.GetComponent<Health>().TakeDamage(damage);
    }
}
