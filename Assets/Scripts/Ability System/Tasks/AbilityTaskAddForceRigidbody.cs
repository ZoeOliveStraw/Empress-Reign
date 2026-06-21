using Ability_System;
using UnityEngine;

public class AbilityTaskAddForceRigidbody : AbilityTask
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float JumpForce;
    [SerializeField] private bool UseParamValues = false;

    private Rigidbody rb;

    protected override void Execute()
    {
        base.Execute();
        if (rb == null)
        {
            rb = myAbility.myParams.AffectedGameObject.GetComponent<Rigidbody>();
        }
        Vector3 force = UseParamValues ? myAbility.myParams.Direction : direction * JumpForce;
        rb.AddForce(force);
    }
}
