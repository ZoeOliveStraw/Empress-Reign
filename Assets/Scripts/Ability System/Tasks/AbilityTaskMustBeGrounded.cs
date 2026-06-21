using Ability_System;
using Managers;
using UnityEngine;

public class AbilityTaskMustBeGrounded : AbilityTask
{
    [SerializeField] private GroundCheck groundCheck;

    public override bool CanExecuteTask()
    {
        if (groundCheck == null)
        {
            groundCheck = PlayerManager.Instance.PlayerGO.GetComponent<GroundCheck>();
        }
        return groundCheck.CanJump;
    }
}
