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
        
        public Actor _currentActor;

        // Update is called once per frame
        void Update()
        {
            CheckForInteractables();
        }

        private void CheckForInteractables()
        {
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out var hit, interactionDistance))
            {
                Actor hitActor = hit.collider.gameObject.GetComponent<Actor>();
                if (hitActor != null)
                {
                    _currentActor = hitActor;
                    objectLabel.text = _currentActor.actorName;
                    return;
                }
                _currentActor = null;
                
            }
            objectLabel.text = "";
        }
    }
}
