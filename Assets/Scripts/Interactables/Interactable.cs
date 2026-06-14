using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Interactables
{
    public class Interactable : MonoBehaviour
    {
        public string label;
        [SerializeField] private UnityEvent onInteracted;

        private void Awake()
        {
            onInteracted.AddListener(DebugMethod);
        }

        public virtual void OnInteracted()
        {
            onInteracted?.Invoke();
        }

        private void DebugMethod()
        {
            Debug.LogWarning($"{label} SAYS PEEPEE POOPOO");
        }

        public Transform GetPlayerReference()
        {
            if(SceneLoader.Instance != null) return SceneLoader.Instance.GetPlayer().transform;
            return GameObject.FindGameObjectWithTag("PlayerController").transform;
        }
    }
}
