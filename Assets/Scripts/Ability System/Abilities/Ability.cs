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

        private List<Task> tasks;

        private void Start()
        {
            GetTasks();
        }

        private void GetTasks()
        {
            tasks = GetComponents<Task>().ToList();
            foreach (Task task in tasks)
                task.myAbility = this;
        }

        public void Use(AbilityParams abilityParams = default)
        {
            foreach (Task task in tasks)
            {
                task.abilityParameters = abilityParams;
                task.Execute();
            }
        }
    }
}
