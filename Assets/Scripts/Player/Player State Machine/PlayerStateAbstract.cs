using UnityEngine;

namespace Player.Player_State_Machine
{
    public abstract class PlayerStateAbstract
    {
        protected GroundCheck GroundCheck;
        protected PlayerStats stats;
        protected PlayerMove playerMove;
        protected PlayerLook playerLook;
        protected GameObject PlayerRootGO;
        protected PlayerInputHandler _input;
        protected PlayerHands _playerHands;
        protected PlayerStateController _stateController;

        protected PlayerStateAbstract(GameObject playerRootGo)
        {
            PlayerRootGO = playerRootGo;
            _input = PlayerRootGO.GetComponent<PlayerInputHandler>();
            _playerHands = PlayerRootGO.GetComponent<PlayerHands>();
            _stateController = PlayerRootGO.GetComponent<PlayerStateController>();
            stats = PlayerRootGO.GetComponent<PlayerStats>();
        }

        protected void GetComponentReferences()
        {
            if(playerMove == null) playerMove = PlayerRootGO.GetComponent<PlayerMove>();
            if(playerLook == null) playerLook = PlayerRootGO.GetComponent<PlayerLook>();
            if(GroundCheck == null) GroundCheck = PlayerRootGO.GetComponent<GroundCheck>();
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();

        public abstract void FixedUpdate();
    }
}