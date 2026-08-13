using System;
using System.Collections;
using Ability_System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private AbilityManager abilities;
    [SerializeField] private Ability onPress;
    [SerializeField] private Ability onRelease;
    [SerializeField] private Ability onHold;
    [SerializeField] private Ability onHit;
    [SerializeField] private Ability onEquip;
    [SerializeField] private Ability onUnequip;
    [SerializeField] private Transform modelParent;
    [SerializeField] private Transform LerpTargetTransform;

    [SerializeField] private float EquipDuration = 0.2f;

    public Action OnEquipStartAction;
    public Action OnEquipFinishAction;
    public Action OnUnequipStartAction;
    public Action OnUnequipFinishAction;

    private Actor myActor;
    private bool isHolding = false;

    private InputSystem_Actions input;

    private void OnEnable()
    {
        if (input == null) InitializeInput();
        input.Enable();
    }

    private void InitializeInput()
    {
        input = new InputSystem_Actions();
        input.Player.Attack.performed += ctx => OnPress();
        input.Player.Attack.canceled += ctx => OnRelease();
    }

    private void OnDisable()
    {
        input.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(Actor actor)
    {
        myActor = actor;
        abilities.Initialize(actor);
        onEquip.Use();
    }

    public void OnPress()
    {
        isHolding = true;
        onPress.Use();
        Debug.Log("OnPress");
    }

    public void OnRelease()
    {
        isHolding = false;
        if(isHolding) onRelease.Use();
        Debug.Log("OnRelease");
    }

    // Update is called once per frame
    void Update()
    {
        if (!input.Player.Attack.IsPressed() && isHolding) OnRelease();
    }

    public void UnequipWeapon()
    {
        StartCoroutine(UnequipWeaponCoroutine());
    }

    private IEnumerator UnequipWeaponCoroutine()
    {
        OnUnequipStartAction?.Invoke();
        onUnequip.Use();
        yield return new WaitForSeconds(EquipDuration);
        OnUnequipFinishAction?.Invoke();
    }
    
    public void EquipWeapon()
    {
        StartCoroutine(EquipWeaponCoroutine());
    }

    private IEnumerator EquipWeaponCoroutine()
    {
        OnEquipStartAction?.Invoke();
        onEquip.Use();
        yield return new WaitForSeconds(EquipDuration);
        OnEquipFinishAction?.Invoke();
    }
}
