using Ability_System;
using UnityEngine;

public class TaskAddForceRigidbody : Task
{
    [SerializeField] private float JumpForce;

    private Rigidbody rb;

    protected override void DoTask()
    {
        Debug.LogWarning("DoTask called in TaskAddForceRigidbody");
        if(rb == null) rb = abilityParameters.AffectedGameObject.GetComponent<Rigidbody>();
        rb.AddForce(abilityParameters.Direction);
    }
}
