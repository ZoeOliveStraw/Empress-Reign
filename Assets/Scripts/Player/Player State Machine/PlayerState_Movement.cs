using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Player_State_Machine
{
    public class PlayerState_Movement : PlayerStateAbstract
    {
        private bool _canAttack = true;
    
        public PlayerState_Movement(GameObject playerRootGo) : base(playerRootGo)
        {
            PlayerRootGO = playerRootGo;
        }

        public override void Enter()
        {
            Debug.LogWarning("Enter PlayerState_Movement");
            GetComponentReferences();
            _input.Input.Player.Jump.performed += Jump;
            _input.Input.Player.Attack.performed += Attack;
        }

        public override void Update()
        {
            //playerMove?.Move(_input.Move, stats.MoveSpeed, stats.Acceleration);
            playerLook?.Look(_input.Look);
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            playerMove.Jump();
        }
        
        private void Attack(InputAction.CallbackContext ctx)
        {
            if(_canAttack) _stateController.SetState(Enum_PlayerStates.Attacking);
        }

        public override void Exit()
        {
            _input.Input.Player.Jump.performed -= Jump;
            _input.Input.Player.Attack.performed -= Attack;
        }

        public override void FixedUpdate()
        {
            
        }
    }
}
