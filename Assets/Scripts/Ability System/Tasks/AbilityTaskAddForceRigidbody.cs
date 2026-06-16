using Ability_System;
using UnityEngine;

public class AbilityTaskAddForceRigidbody : AbilityTask
{
    [SerializeField] private float JumpForce;

    private Rigidbody rb;

    public override void Execute()
    {
        if (rb == null)
        {
            rb = myAbility.myParams.AffectedGameObject.GetComponent<Rigidbody>();
        }
        rb.AddForce(Vector3.up * JumpForce);
    }
}
