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
        if(LevelManager.Instance != null) return LevelManager.Instance.GetPlayer().transform;
        return GameObject.FindGameObjectWithTag("PlayerController").transform;
    }
}
