using System.Linq;
using Ability_System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Ability Move;
        [SerializeField] private Ability Jump;
        [SerializeField] private Ability Look;
        [SerializeField] public Transform cameraAnchor;
        
        private PlayerInputHandler input;
        private AbilityManager abilityManager;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            input = GetComponent<PlayerInputHandler>();
            abilityManager = GetComponent<AbilityManager>();

            input.InteractAction.performed += ctx => abilityManager.UseAbility("Interact");
            input.JumpAction.performed += ctx => 
                abilityManager.UseAbility("Jump",
                    new AbilityParams(gameObject));
        }

        // Update is called once per frame
        void Update()
        {
            Move.Use(new AbilityParams(inputAxis: input.Move));
            Look.Use(new AbilityParams(inputAxis: input.Look));
        }
    }
}
