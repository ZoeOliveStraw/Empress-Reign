using System;
using UnityEngine;

namespace Ability_System
{
    [RequireComponent(typeof(Ability))]
    public class AbilityTask : MonoBehaviour
    {
        [SerializeField] private string debugMessage;
        
        private bool _onCooldown = false;
        private bool _startRequested = false;

        private float timeSinceStartRequested;
        private float remainingCooldown;
        public Ability myAbility;

        public virtual void Execute()
        {
            Debug.Log(debugMessage);
        }

        public virtual bool CanExecuteTask()
        {
            return true;
        }
    }
}
