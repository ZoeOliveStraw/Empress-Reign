using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ability_System
{
    public class InteractableAbilityBased : MonoBehaviour
    {
        [SerializeField] public string actorName;
        [SerializeField] private List<Ability> onStartAbilities = new List<Ability>();
        [SerializeField] private List<Ability> onActivateAbilities = new List<Ability>();

        private void Start()
        {
            foreach (Ability ability in onStartAbilities)
            {
                ability.abilityOwner = gameObject;
                ability.Use();
            }

            foreach (Ability ability in onActivateAbilities)
            {
                ability.abilityOwner = gameObject;
            }
        }

        public void OnInteraction(GameObject affectedGameObject)
        {
            foreach (Ability ability in onActivateAbilities)
            {
                ability.Use(new AbilityParams(
                    affectedGameObject: affectedGameObject));
            }
        }
    }
}