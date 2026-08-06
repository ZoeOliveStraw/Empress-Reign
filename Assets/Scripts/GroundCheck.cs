using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Actor actor;
    
    [Header("Ground Check Points")]
    [SerializeField] private List<Transform> groundCheckPoints;

    [Header("Ground Check Settings")]
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float coyoteTime = 0.2f;

    private float currentCoyoteTime;

    private bool IsGrounded { get; set; }

    private void Update()
    {
        IsGrounded = DoGroundCheck();
        actor.Flags.SetFlag(EnumCharacterFlags.Grounded, IsGrounded);
    }

    private bool DoGroundCheck()
    {
        foreach (Transform groundCheckPoint in groundCheckPoints)
        {
            if (GroundCheckRaycast(groundCheckPoint)) return true;
        }
        return false;
    }

    private bool GroundCheckRaycast(Transform groundCheckPoint)
    {
        return Physics.Raycast(
            groundCheckPoint.position,
            Vector3.down,
            checkDistance,
            groundLayers
        );
    }
}
