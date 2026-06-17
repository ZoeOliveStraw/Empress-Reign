using System;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float MoveSpeed;
        [SerializeField] private float Accelleration;
        [SerializeField] private bool TankControls;
        [SerializeField] private float jumpForce;
        [SerializeField] private Rigidbody rb;

        private PlayerGroundCheck groundCheck;
        private Vector2 _currentMoveVector = Vector2.zero;
        private float _yaw;
        private PlayerInputHandler input;

        public void Move(Vector2 moveVector)
        {
            if (TankControls)
            {
                moveVector = new Vector2(0, moveVector.y);
            }
            Vector2 targetMoveVector = moveVector * MoveSpeed;
            _currentMoveVector = Vector2.Lerp(_currentMoveVector, targetMoveVector, Accelleration * Time.deltaTime);
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector3 movement = right * _currentMoveVector.x + forward * _currentMoveVector.y;
            transform.position += movement * Time.deltaTime;
        }

        public void Jump()
        {
            if(groundCheck == null ) groundCheck = GetComponent<PlayerGroundCheck>();
            if (!groundCheck.CanJump) return;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
