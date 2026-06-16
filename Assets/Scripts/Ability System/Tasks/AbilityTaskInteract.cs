using Ability_System;
using UnityEngine;

public class AbilityTaskInteract : AbilityTask
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float interactionRange;
}
