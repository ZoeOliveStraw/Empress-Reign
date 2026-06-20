using System;
using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskMovementRigidbody : AbilityTask
    {
        [SerializeField] private float MoveSpeed;
        [SerializeField] private float Accelleration;

        private Transform characterToMove;
        private Vector2 _currentMoveVector = Vector2.zero;

        private void Start()
        {
            characterToMove = myAbility.abilityOwner.transform;
        }

        protected override void Execute()
        {
            base.Execute();
            if (characterToMove == null)
            {
                characterToMove = myAbility.abilityOwner.transform;
            }
            Move(myAbility.myParams.InputAxis);
        }

        public void Move(Vector2 moveVector)
        {
            Vector2 targetMoveVector = moveVector * MoveSpeed;
            _currentMoveVector = Vector2.Lerp(_currentMoveVector, targetMoveVector, Accelleration * Time.deltaTime);
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector3 movement = right * _currentMoveVector.x + forward * _currentMoveVector.y;
            characterToMove.position += movement * Time.deltaTime;
        }
    }
}
