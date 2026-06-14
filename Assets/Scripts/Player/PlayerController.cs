using Ability_System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputHandler input;
        private PlayerMove move;
        private PlayerLook look;
        private AbilityManager abilityManager;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            input = GetComponent<PlayerInputHandler>();
            move = GetComponent<PlayerMove>();
            look = GetComponent<PlayerLook>();
            abilityManager = GetComponent<AbilityManager>();

            input.InteractAction.performed += ctx => abilityManager.UseAbility("Interact");
            input.JumpAction.performed += ctx => 
                abilityManager.UseAbility("Jump",
                new AbilityParams(gameObject,
                    Vector3.up * 10));
        }

        // Update is called once per frame
        void Update()
        {
            move.Move(input.Move);
            look.Look(input.Look);
        }
    }
}
