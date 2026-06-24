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
            rb = myAbility.myActor.GetComponent<Rigidbody>();
        }
        Vector3 force = UseParamValues ? myAbility.myParams.Axis3D : direction * JumpForce;
        rb.AddForce(force);
    }
}
