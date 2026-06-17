using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] protected int currentHealth = 25;
    [SerializeField] protected int maxHealth = 25;

    public virtual void TakeDamage(int damage, DamageType damageType = DamageType.Normal)
    {
        currentHealth -= damage;
    }

    public virtual void OnHealthReachZero()
    {
        
    }
}
