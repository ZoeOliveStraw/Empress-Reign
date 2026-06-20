using Ability_System;
using Managers;
using UnityEngine;

public class EnemyBasicMelee : MonoBehaviour
{
    [SerializeField] private AbilityManager abilityManager;
    [SerializeField] private Ability move;
    [SerializeField] private Ability attack;
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;
    
    private GameObject player;
    private float distanceToPlayer;
    
    private void Start()
    {
        GetPlayerReference();
    }

    private void Update()
    {
        EnemyLogic();
    }

    private void GetPlayerReference()
    {
        player = PlayerManager.Instance.PlayerGO;
    }

    private void EnemyLogic()
    {
        if(player == null) GetPlayerReference();
        distanceToPlayer = DistanceToPlayer();
        if (distanceToPlayer <= attackRange)
        {
            attack.Use(new AbilityParams(targetGameObject: player));
        }
        else if(distanceToPlayer <= chaseRange) move.Use(new AbilityParams(targetGameObject: player));
    }

    private float DistanceToPlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
