using System.Linq;
using Ability_System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Ability Move;
        [SerializeField] private Ability Look;
        [SerializeField] public Transform cameraAnchor;
        [SerializeField] public MainHand MainHand;
        [SerializeField] private PlayerInteraction interaction;

        [Header("DEBUG STUFF")] 
        [SerializeField] public GameObject slot1Prefab;
        
        private PlayerInputHandler input;
        private AbilityManager abilityManager;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            input = GetComponent<PlayerInputHandler>();
            abilityManager = GetComponent<AbilityManager>();
            
            input.JumpAction.performed += ctx => 
                abilityManager.UseAbility("Jump",
                    new AbilityParams(gameObject));

            input.InteractAction.performed += ctx => Interact();
            input.Hotkey1Action.performed += ctx => MainHand.EquipMainHandAbility(slot1Prefab);
            input.MainHandAction.performed += ctx => MainHand.UseMainHandAbility();
        }

        // Update is called once per frame
        void Update()
        {
            Move.Use(new AbilityParams(inputAxis: input.Move));
            Look.Use(new AbilityParams(inputAxis: input.Look));
        }

        private void Interact()
        {
            if (interaction._currentInteractable == null) return;
            
            abilityManager.UseAbility("Interact",
                new AbilityParams(affectedGameObject: gameObject,
                    interactable: interaction._currentInteractable));
        }
    }
}
