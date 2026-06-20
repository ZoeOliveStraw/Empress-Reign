using System;
using UnityEngine;
using UnityEngine.AI;

namespace Ability_System.Tasks
{
    public class AbilityTaskMoveNavmesh : AbilityTask
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private float moveSpeed;

        
        
        private void GetNavMeshAgent()
        {
            navMeshAgent = myAbility.abilityOwner.gameObject.GetComponent<NavMeshAgent>();
        }

        protected override void Execute()
        {
            base.Execute();
            if(navMeshAgent == null) GetNavMeshAgent();
            navMeshAgent.SetDestination(myAbility.myParams.TargetGameObject.transform.position);
        }
    }
}
