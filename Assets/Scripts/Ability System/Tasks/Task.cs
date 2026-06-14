using System;
using UnityEngine;

namespace Ability_System
{
    [RequireComponent(typeof(Ability))]
    public class Task : MonoBehaviour
    {
        [SerializeField] private float startDelay = 0;
        [SerializeField] private float cooldown = 0;
        [SerializeField] private string debugMessage;
        
        private bool _onCooldown = false;
        private bool _startRequested = false;

        private float timeSinceStartRequested;
        private float remainingCooldown;
        public Ability myAbility;
        
        public AbilityParams abilityParameters;

        public void Execute()
        {
            DoTask();
        }

        private void Update()
        {
            
        }

        private void StartDelay()
        {
            startDelay += Time.deltaTime;
        }

        private void CoolDown()
        {
            remainingCooldown -= Time.deltaTime;
            remainingCooldown = Mathf.Clamp(remainingCooldown, 0, cooldown);
            if (remainingCooldown <= 0)
            {
                _onCooldown = false;
            }
            else
            {
                _onCooldown = true;
            }
        }

        protected virtual void DoTask()
        {
            Debug.LogWarning("DoTask called in Task");
        }
    }
}
