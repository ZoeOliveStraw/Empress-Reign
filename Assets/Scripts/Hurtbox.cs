using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] private Health health;
    

    public void TakeDamage(float damage)
    {
        Debug.LogWarning($"{gameObject.name} takes {damage} damage");
    }
}
