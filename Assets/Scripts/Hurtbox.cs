using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    

    public void TakeDamage(float damage)
    {
        Debug.LogWarning($"{gameObject.name} takes {damage} damage");
    }
}
