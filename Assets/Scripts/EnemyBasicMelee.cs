using System;
using Ability_System;
using Managers;
using UnityEngine;

public class EnemyBasicMelee : MonoBehaviour
{
    [SerializeField] private AbilityManager abilityManager;

    [SerializeField] private Ability move;
    
    [SerializeField] private float PlayerDetectionRange;
    [SerializeField] private GameObject Player;

    private void Start()
    {
        GetPlayerReference();
    }

    private void Update()
    {
        if(Player == null) GetPlayerReference();
        EnemyLogic();
    }

    private void GetPlayerReference()
    {
        Player = PlayerManager.Instance.PlayerGO;
    }

    private void EnemyLogic()
    {
        move.Use(new AbilityParams(targetGameObject: Player));
    }
}
