using UnityEngine;

namespace Ability_System
{
    public struct AbilityParams
    {
        public GameObject AffectedGameObject;
        public GameObject TargetGameObject;
        public Vector3 Direction;
        public Vector2 InputAxis;
        public InteractableAbilityBased Interactable;

        public AbilityParams(
            GameObject affectedGameObject = null,
            Vector3 direction = default,
            Vector2 inputAxis = default,
            GameObject targetGameObject = null,
            InteractableAbilityBased interactable = null,
            Inventory inventory = null)

        {
            AffectedGameObject = affectedGameObject;
            Direction = direction;
            InputAxis = inputAxis;
            TargetGameObject = targetGameObject;
            Interactable = interactable;
        }
    }
}