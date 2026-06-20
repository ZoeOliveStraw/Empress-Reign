using Ability_System;
using UnityEngine;

public class AbilityTaskAddForceRigidbody : AbilityTask
{
    [SerializeField] private float JumpForce;

    private Rigidbody rb;

    protected override void Execute()
    {
        base.Execute();
        if (rb == null)
        {
            rb = myAbility.myParams.AffectedGameObject.GetComponent<Rigidbody>();
        }
        rb.AddForce(Vector3.up * JumpForce);
    }
}
