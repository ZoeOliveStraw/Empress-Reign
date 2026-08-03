using System.Collections.Generic;
using Ability_System;
using Attribute_System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] public string actorName;
    [SerializeField] public List<MultiTag.MultiTags> Tags = new();
    [SerializeField] public AbilityManager Abilities;
    [SerializeField] public CharacterAttributes Attributes;
    [SerializeField] public CharacterFlags Flags;
    
    [Header("Events")]
    [SerializeField] private List<Ability> onStartAbilities = new();
    [SerializeField] private List<Ability> onActivateAbilities = new();
    [SerializeField] private List<Ability> onDestroyAbilities = new();
    [SerializeField] private List<Ability> onTriggerEnterAbilities = new();

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if(Attributes != null )Attributes.Initialize();
        if(Flags != null ) Flags.Initialize();
        if(Abilities != null ) Abilities.Initialize(this);
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
    
    [SerializeField] public List<MultiTag.MultiTags> triggerTags = new();
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log($"OnTriggerEnter on actor: {col.gameObject.name}");
        Actor actor = col.gameObject.GetComponent<Actor>();
        if (actor == null)
        {
            Debug.Log("Actor null, returning.");
            return;
        }
        foreach (MultiTag.MultiTags multiTag in triggerTags)
        {
            if(actor.Tags.Contains(multiTag)) OnTriggerEnterAbilities(actor);
        }
    }

    private void OnTriggerEnterAbilities(Actor actor)
    {
        Debug.Log($"OnTriggerEnterAbilities called");
        AbilityParams newParams = new AbilityParams(
            myActor: this,
            targetActor:actor);
        foreach (Ability ability in onTriggerEnterAbilities)
        {
            ability.Use(newParams);
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
