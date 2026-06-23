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
        private Actor myActor;

        public void Initialize(Actor actor)
        {
            myActor = actor;
            GetAbilities();
        }

        private void GetAbilities()
        {
            abilities = abilityContainer.GetComponentsInChildren<Ability>().ToList();
            foreach (Ability ability in abilities)
            {
                ability.Initialize(myActor);
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
