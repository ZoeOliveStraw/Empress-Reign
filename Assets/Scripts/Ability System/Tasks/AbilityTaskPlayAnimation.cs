using Ability_System;
using UnityEngine;

public class AbilityTaskPlayAnimation : AbilityTask
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    private float animationDuration = 1;

    protected override void Execute()
    {
        animator.speed = 1/animationDuration;
        animator.Play(animationName);
    }

    public void SetSpeed(float duration)
    {
        animationDuration = duration;
    }
}
