using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        
        private InputSystem_Actions _input;
        public InputSystem_Actions Input
        {
            get
            {
                if (_input == null)
                {
                    _input = new InputSystem_Actions();
                    _input.Enable();
                }
                return _input;
            }
        }
        public Vector2 Move => Input.Player.Move.ReadValue<Vector2>();
        public Vector2 Look => Input.Player.Look.ReadValue<Vector2>();
        public InputAction JumpAction => Input.Player.Jump;
        public InputAction InteractAction => Input.Player.Interact;

        // Update is called once per frame
        void OnEnable()
        {
            Input.Enable();
        }
    
        void OnDisable()
        {
            Input.Disable();
        }
    }
}
