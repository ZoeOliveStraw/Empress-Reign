using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ability_System
{
    [DisallowMultipleComponent]
    public class Ability : MonoBehaviour
    {
        private enum State
        {
            None,
            Executing,
            End,
            Cancelled
        }

        public string abilityName;
        public GameObject abilityOwner;
        private List<AbilityTask> tasks;
        public AbilityParams myParams;

        private void Start()
        {
            GetTasks();
        }

        private void GetTasks()
        {
            tasks = GetComponents<AbilityTask>().ToList();
            foreach (AbilityTask task in tasks)
                task.myAbility = this;
        }

        public void Use(AbilityParams abilityParams = default)
        {
            myParams = abilityParams;
            foreach (AbilityTask task in tasks)
            {
                if (!task.CanExecuteTask())
                {
                    return;
                }
            }
            foreach (AbilityTask task in tasks)
            {
                task.Execute();
            }
        }
    }
}
