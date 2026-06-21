using Attribute_System;
using UnityEngine;
using Attribute = Attribute_System.Attribute;

namespace Ability_System.Tasks
{
    public class AbilityTaskMoveRigidbody_Attribute : AbilityTask
    {
        [SerializeField] private float MoveSpeedMultiplier;
        [SerializeField] private float Accelleration;

        private Transform _characterToMove;
        private Vector2 _currentMoveVector = Vector2.zero;
        private float _moveSpeed;
        private Attribute _speedAttribute;

        private void Start()
        {
            _characterToMove = myAbility.abilityOwner.transform;
            CalculateMoveSpeed();   
        }

        private void CalculateMoveSpeed()
        {
            if(_speedAttribute == null) 
            {
                _speedAttribute = 
                myAbility.abilityOwner.GetComponent<CharacterAttributes>().GetAttribute(Attributes.Speed);
                _speedAttribute.OnValueChanged.AddListener(CalculateMoveSpeed);
            }
            _moveSpeed = _speedAttribute.currentValue * MoveSpeedMultiplier;
        }

        protected override void Execute()
        {
            base.Execute();
            if (_characterToMove == null)
            {
                _characterToMove = myAbility.abilityOwner.transform;
            }
            Move(myAbility.myParams.InputAxis);
        }

        public void Move(Vector2 moveVector)
        {
            Vector2 targetMoveVector = moveVector * _moveSpeed;
            _currentMoveVector = Vector2.Lerp(_currentMoveVector, targetMoveVector, Accelleration * Time.deltaTime);
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector3 movement = right * _currentMoveVector.x + forward * _currentMoveVector.y;
            _characterToMove.position += movement * Time.deltaTime;
        }
    }
}
