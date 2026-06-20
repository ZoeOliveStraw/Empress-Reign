using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] private Health health;
    

    public void TakeDamage(int damage, DamageType damageType = DamageType.Normal)
    {
        health.TakeDamage(damage, damageType);
        Debug.LogWarning($"{gameObject.name} takes {damage} damage");
    }
}
