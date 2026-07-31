using Managers;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public virtual void OnActivate()
    {
        Debug.LogWarning($"{gameObject.name} activated!");
    }

    public Transform GetPlayerTransform()
    {
        return GameObject.FindGameObjectWithTag("PlayerController").transform;
    }
}
