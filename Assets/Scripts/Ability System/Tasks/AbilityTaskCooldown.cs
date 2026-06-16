using System;
using Ability_System;
using UnityEngine;

public class AbilityTaskCooldown : AbilityTask
{
    [SerializeField] private float cooldown;

    private float _cooldownTimer = 0;
    private bool isOnCooldown = false;

    public override void Execute()
    {
        isOnCooldown = true;
        _cooldownTimer = 0;
    }

    private void Update()
    {
        if (isOnCooldown)
        {
            _cooldownTimer += Time.deltaTime;
            if (_cooldownTimer >= cooldown)
            {
                _cooldownTimer = 0;
                isOnCooldown = false;
            }
        }
        
    }

    public override bool CanExecuteTask()
    {
        return !isOnCooldown;
    }
}
