using System;
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
    }
}
