using UnityEngine;

namespace Player.Player_State_Machine
{
    public class PlayerState_Menu : PlayerStateAbstract
    {
        public PlayerState_Menu(GameObject playerRootGo) : base(playerRootGo)
        {
            PlayerRootGO = playerRootGo;
        }

        public override void Enter()
        {
            Debug.Log("Enter");
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
        
        }

        public override void FixedUpdate()
        {
        
        }
    }
}
