using Ability_System;
using UnityEngine;

public class AbilityTaskPlayAnimation : AbilityTask
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;

    protected override void Execute()
    {
        animator.Play(animationName);
    }
}
