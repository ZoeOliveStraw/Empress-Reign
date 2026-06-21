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
        
        public InteractableAbilityBased _currentInteractable;

        // Update is called once per frame
        void Update()
        {
            CheckForInteractables();
        }

        private void CheckForInteractables()
        {
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out var hit, interactionDistance))
            {
                InteractableAbilityBased interactable = hit.collider.gameObject.GetComponent<InteractableAbilityBased>();
                if (interactable != null)
                {
                    _currentInteractable = interactable;
                    objectLabel.text = _currentInteractable.actorName;
                    return;
                }
                _currentInteractable = null;
                
            }
            objectLabel.text = "";
        }
    }
}
