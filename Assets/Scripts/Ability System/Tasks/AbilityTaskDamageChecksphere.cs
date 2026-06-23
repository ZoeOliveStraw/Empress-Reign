using Ability_System;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityTaskDamageChecksphere : AbilityTask
{
    [SerializeField] private int damage;
    [SerializeField] private float checkSphereRadius;
    [SerializeField] private Transform checkSphereOriginTransform;
    
    protected override void Execute()
    {
        base.Execute();
        DamageTargetsInRadius();
    }

    private void DamageTargetsInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(checkSphereOriginTransform.position, checkSphereRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.CompareTag("Multitag") && collider.gameObject != myAbility.myActor.gameObject)
            {
                Debug.LogWarning("Damaging player!");
                Hurtbox hurtbox = collider.gameObject.GetComponent<Hurtbox>();
                hurtbox.TakeDamage(damage);
            }
        }
    }
}
