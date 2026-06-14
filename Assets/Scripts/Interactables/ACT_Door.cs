using System;
using Managers;
using UnityEngine;

public class ACT_Door : Activator
{
    [SerializeField] private float openSpeed;
    [Range(50, 180)][SerializeField] private float openAmount = 90;
    [SerializeField] private Transform doorHinge;
    [SerializeField] private bool isLocked;
    [SerializeField] private bool isOpen;
    [SerializeField] private Collider collider;
    [SerializeField] private bool disableColliderWhileMoving;

    private float CurrentTargetRotation = 0;
    private bool isMoving;

    public override void OnActivate()
    {
        isOpen = !isOpen;
        if(isOpen) Open();
        else Close();
    }

    private void Update()
    {
        if(isMoving) RotateTowardsTarget();
        if (IsAtTargetRotation()) isMoving = false;
        else isMoving = true;
    }

    private float GetTargetRotation()
    {
        Transform player = GetPlayerTransform();
        Vector3 toPlayer = player.position - doorHinge.position;
        float side = Vector3.Dot(doorHinge.right, toPlayer);
        float angle = side > 0 ? openAmount : -openAmount;
        float baseY = doorHinge.localEulerAngles.y;
        return baseY + angle;
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRot = Quaternion.Euler(0f, CurrentTargetRotation, 0f);
        doorHinge.localRotation = Quaternion.Slerp(
            doorHinge.localRotation,
            targetRot,
            Time.deltaTime * openSpeed);
    }
    
    public bool IsAtTargetRotation(float threshold = 0.1f)
    {
        float currentY = doorHinge.localEulerAngles.y;
        float delta = Mathf.DeltaAngle(currentY, CurrentTargetRotation);
        return Mathf.Abs(delta) <= threshold;
    }
    
    private void Open()
    {
        CurrentTargetRotation = GetTargetRotation();
    }

    private void Close()
    {
        CurrentTargetRotation = 0;
    }
}
