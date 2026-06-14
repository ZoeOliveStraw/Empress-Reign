using System.Collections.Generic;
using Player;
using Player.Player_State_Machine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState_Attacking : PlayerStateAbstract
{
    private int _attackDamage;

    private float remainingAttackDuration;
    private float remainingDamageDuration;

    private bool _attackQueued = false;

    private List<Hurtbox> _hurtboxesHitThisAttack;

    public PlayerState_Attacking(GameObject playerRootGo) : base(playerRootGo)
    {
        _hurtboxesHitThisAttack = new List<Hurtbox>();
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter PlayerState_Attacking");
        GetComponentReferences();
        CalculateAttackInfo();
        _hurtboxesHitThisAttack.Clear();
        _playerHands.UseRightHandObject();
        _attackQueued = false;
        _input.Input.Player.Attack.performed += QueueAttack;
    }

    private void CalculateAttackInfo()
    {
        SO_InventoryWeapon weapon = PlayerRootGO.GetComponent<PlayerEquipment>().equipmentSlots.RightHand;
        _attackDamage = (int)weapon.baseDamage;
        remainingAttackDuration = weapon.baseAttackSpeed;
        remainingDamageDuration = weapon.baseAttackSpeed / 2f;
    }

    public override void Update()
    {
        //playerMove?.Move(_input.Move, stats.MoveSpeed, stats.Acceleration);
        playerLook?.Look(_input.Look);
        remainingAttackDuration -= Time.deltaTime;
        remainingDamageDuration -= Time.deltaTime;

        if (remainingDamageDuration > 0f)
        {
            CheckForHurtboxes();
        }

        if (remainingAttackDuration > 0f) return;

        if (_attackQueued)
        {
            Debug.LogWarning("Attack _attackQueued, going back to attacking state");
            _stateController.SetState(Enum_PlayerStates.Attacking);
        }

        else
        {
            Debug.LogWarning("NONE queued, going back to movement");
            _stateController.SetState(Enum_PlayerStates.Movement);
        }
    }

    private void CheckForHurtboxes()
    {
        List<Hurtbox> hitObjects = _playerHands.rightHandObject.CheckPointsForDamangeable();

        foreach (Hurtbox hitObject in hitObjects)
        {
            if (hitObject == null) continue;

            if (!_hurtboxesHitThisAttack.Contains(hitObject))
            {
                hitObject.TakeDamage(_attackDamage);
                _hurtboxesHitThisAttack.Add(hitObject);
            }
        }
    }

    private void QueueAttack(InputAction.CallbackContext ctx)
    {
        if (remainingDamageDuration <= 0) _attackQueued = true;
    }

    public override void Exit()
    {
        _input.Input.Player.Attack.performed -= QueueAttack;
    }

    public override void FixedUpdate()
    {
    }
}
