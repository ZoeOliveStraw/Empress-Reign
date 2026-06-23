using System.Linq;
using Ability_System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Actor myActor;
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
                    new AbilityParams(myActor));

            input.InteractAction.performed += ctx => Interact();
            input.Hotkey1Action.performed += ctx => MainHand.EquipMainHandAbility(slot1Prefab);
            input.MainHandAction.performed += ctx => MainHand.UseMainHandAbility();
        }

        // Update is called once per frame
        void Update()
        {
            Move.Use(new AbilityParams(axis2D: input.Move));
            Look.Use(new AbilityParams(axis2D: input.Look));
        }

        private Actor MyActor()
        {
            if(myActor == null) myActor = GetComponent<Actor>();
            return myActor;
        }

        private void Interact()
        {
            if (interaction._currentActor == null) return;
            
            abilityManager.UseAbility("Interact",
                new AbilityParams(myActor: interaction._currentActor,
                    targetActor: myActor));
        }
    }
}
