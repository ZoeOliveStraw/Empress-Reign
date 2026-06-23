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
        public Actor myActor;
        private List<AbilityTask> tasks;
        public AbilityParams myParams;

        public void Initialize(Actor actor)
        {
            myActor = actor;
            GetTasks();
        }

        private void GetTasks()
        {
            tasks = GetComponents<AbilityTask>().OrderBy(t => t.ExecutionPriority).ToList();
            foreach (AbilityTask task in tasks) task.Initialize(this);
        }

        public void Use(AbilityParams abilityParams = default)
        {
            Debug.LogWarning($"{abilityName} used by {myActor.name}");
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
                task.StartExecution();
            }
        }
    }
}
