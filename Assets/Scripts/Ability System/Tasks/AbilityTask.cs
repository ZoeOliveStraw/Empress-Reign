using System;
using System.Collections;
using UnityEngine;

namespace Ability_System
{
    [RequireComponent(typeof(Ability))]
    public class AbilityTask : MonoBehaviour
    {
        [SerializeField] private string debugMessage;
        [SerializeField] private float DelayBeforeExecution = 0;
        
        private bool _onCooldown = false;
        private bool _startRequested = false;

        private float timeSinceStartRequested;
        private float remainingCooldown;
        [HideInInspector] public Ability myAbility;

        public void StartExecution()
        {
            if (DelayBeforeExecution == 0) Execute();
            else
            {
                StartCoroutine(DelayBeforeStart());
            }
        }

        protected virtual void Execute()
        {
            if(!debugMessage.Equals(""))
                Debug.Log(debugMessage);
        }

        public virtual bool CanExecuteTask()
        {
            return true;
        }

        private IEnumerator DelayBeforeStart()
        {
            yield return new WaitForSeconds(DelayBeforeExecution);
            Execute();
        }
    }
}
