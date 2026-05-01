using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private UnityEvent OnHit;
    [SerializeField] private UnityEvent OnHPReachesZero;

    public void TakeDamage(float damage)
    {
        Debug.LogWarning($"{gameObject.name} takes {damage} damage");
    }
}
