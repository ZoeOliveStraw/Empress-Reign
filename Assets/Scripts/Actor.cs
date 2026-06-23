using System.Collections.Generic;
using Ability_System;
using Attribute_System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] public string actorName;
    [SerializeField] public AbilityManager Abilities;
    [SerializeField] public CharacterAttributes Attributes;
    [SerializeField] public CharacterFlags Flags;
    
    [Header("Events")]
    [SerializeField] private List<Ability> onStartAbilities = new List<Ability>();
    [SerializeField] private List<Ability> onActivateAbilities = new List<Ability>();
    [SerializeField] private List<Ability> onDestroyAbilities = new List<Ability>();

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Attributes.Initialize();
        Flags.Initialize();
        Abilities.Initialize(this);
        foreach (Ability ability in onStartAbilities)
        {
            ability.myActor = this;
            ability.Use();
        }
        foreach (Ability ability in onActivateAbilities)
        {
            ability.myActor = this;
        }
    }

    public void OnInteraction(AbilityParams abilityParams)
    {
        foreach (Ability ability in onActivateAbilities)
        {
            ability.Use(abilityParams);
        }
    }
    
    public void OnDestroy()
    {
        foreach (Ability ability in onActivateAbilities)
        {
            ability.Use(GetAbilityParams());
        }
    }

    public AbilityParams GetAbilityParams()
    {
        return new AbilityParams(
            myActor: GetComponent<Actor>());
    }
}
