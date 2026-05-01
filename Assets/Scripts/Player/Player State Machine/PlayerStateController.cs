using UnityEngine;

namespace Player.Player_State_Machine
{
    public enum Enum_PlayerStates
    {
        Movement,
        Menu,
        Attacking,
        Jumping,
        Swimming
    }
    
    public class PlayerStateController : MonoBehaviour
    {
        private PlayerState_Movement playerState_Movement;
        private PlayerState_Menu playerState_Menu;
        private PlayerState_Attacking playerState_Attacking;

        private PlayerStateAbstract previousState;
        private PlayerStateAbstract currentState;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SetState(Enum_PlayerStates.Movement);
        }

        public void SetState(Enum_PlayerStates state)
        {
            switch (state)
            {
                case Enum_PlayerStates.Movement:
                    if (playerState_Movement == null) playerState_Movement = new PlayerState_Movement(gameObject);
                    LoadState(playerState_Movement);
                    break;

                case Enum_PlayerStates.Menu:
                    if (playerState_Menu == null) playerState_Menu = new PlayerState_Menu(gameObject);
                    LoadState(playerState_Menu);
                    break;

                case Enum_PlayerStates.Attacking:
                    if(playerState_Attacking == null) playerState_Attacking = new PlayerState_Attacking(gameObject);
                    LoadState(playerState_Attacking);
                    break;

                case Enum_PlayerStates.Jumping:
                    // LoadState(playerState_Jumping);
                    break;

                case Enum_PlayerStates.Swimming:
                    // LoadState(playerState_Swimming);
                    break;

                default:
                    Debug.LogWarning("Unhandled player state: " + state);
                    break;
            }
        }

        public void LoadState(PlayerStateAbstract stateToLoad)
        {
            if (currentState != null)
            {
                currentState.Exit();
                previousState = currentState;
            }
            currentState = stateToLoad;
            currentState.Enter();
        }
    
    

        private void Update()
        {
            currentState.Update();
        }
    }
}
