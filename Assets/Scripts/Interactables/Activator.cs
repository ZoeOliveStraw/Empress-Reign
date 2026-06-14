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
        if(SceneLoader.Instance != null) return SceneLoader.Instance.GetPlayer().transform;
        return GameObject.FindGameObjectWithTag("PlayerController").transform;
    }
}
