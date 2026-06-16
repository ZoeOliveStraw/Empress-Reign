using Ability_System;
using Managers;
using UnityEngine;

public class AbilityTaskMustBeGrounded : AbilityTask
{
    [SerializeField] private PlayerGroundCheck playerGroundCheck;

    public override bool CanExecuteTask()
    {
        if (playerGroundCheck == null)
        {
            playerGroundCheck = PlayerManager.Instance.PlayerGO.GetComponent<PlayerGroundCheck>();
        }
        return playerGroundCheck.CanJump;
    }
}
