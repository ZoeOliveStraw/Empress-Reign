using System;
using Ability_System;
using Interactables;
using Managers;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionDistance;
        [SerializeField] private Transform raycastOrigin;
        [SerializeField] private string interactableTag;
        [SerializeField] private PlayerInputHandler _input;
        [SerializeField] private TextMeshProUGUI interactionLabel;
        
        public Actor _currentActor;

        private void Start()
        {
            GetInteractionLabel();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInteractables();
        }

        private void GetInteractionLabel()
        {
            interactionLabel = MenuManager.Instance.HUD.GetComponent<HUD_Controller>().selectionLabel;
        }

        private void CheckForInteractables()
        {
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out var hit, interactionDistance))
            {
                Actor hitActor = hit.collider.gameObject.GetComponent<Actor>();
                if (hitActor != null)
                {
                    _currentActor = hitActor;
                    interactionLabel.text = _currentActor.actorName;
                    return;
                }
                _currentActor = null;
                
            }
            interactionLabel.text = "";
        }
    }
}
