using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ability_System
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private Transform abilityContainer;
        private List<Ability> abilities;

        private void Start()
        {
            GetAbilities();
        }

        private void GetAbilities()
        {
            abilities = abilityContainer.GetComponentsInChildren<Ability>().ToList();
            foreach (Ability ability in abilities)
            {
                ability.abilityOwner = gameObject;
            }
        }

        public void UseAbility(string abilityName, AbilityParams abilityParams = default)
        {
            foreach (Ability ability in abilities)
            {
                if (ability.name.Equals(abilityName))
                {
                    ability.Use(abilityParams);
                }
            }
        }
    }
}
