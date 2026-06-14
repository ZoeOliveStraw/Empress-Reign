using Ability_System;
using Interactables;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionDistance;
        [SerializeField] private Transform raycastOrigin;
        [SerializeField] private string interactableTag;
        [SerializeField] private TextMeshProUGUI objectLabel;
        [SerializeField] private PlayerInputHandler _input;
        
        private Interactable _currentInteractable;

        private void Start()
        {
            _input.Input.Player.Interact.performed += ctx => OnInteract();
            _input.Input.Player.Interact.performed += ctx => OnInteractAbility();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInteractables();
        }

        private void CheckForInteractables()
        {
            _currentInteractable = InteractableRaycast();
            if (_currentInteractable != null)
            {
                objectLabel.text = _currentInteractable.label;
            }
            else
            {
                objectLabel.text = "";
            }
        }

        private Interactable InteractableRaycast()
        {
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out var hit, interactionDistance))
            {
                if (hit.collider.transform.CompareTag(interactableTag))
                {
                    return hit.collider.gameObject.GetComponent<Interactable>();
                }
            }
            return null;
        }

        private void OnInteract()
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.OnInteracted();
            }
        }

        private void OnInteractAbility()
        {
            GetComponent<AbilityManager>().UseAbility("Interact");
        }
    }
}
