using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [Header("Ground Check Points")]
    [SerializeField] private List<Transform> groundCheckPoints;

    [Header("Ground Check Settings")]
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private LayerMask groundLayers = ~0;
    [SerializeField] private float coyoteTime = 0.2f;

    private float currentCoyoteTime;

    private bool IsGrounded { get; set; }
    public bool CanJump  { get; set; }

    private void Update()
    {
        IsGrounded = CheckGrounded();
        UpdateCoyoteTime();
        CanJump = IsGrounded || currentCoyoteTime > 0;
    }

    private bool CheckGrounded()
    {
        if (groundCheckPoints == null || groundCheckPoints.Count == 0)
            return false;

        for (int i = 0; i < groundCheckPoints.Count; i++)
        {
            Transform point = groundCheckPoints[i];
            if (point == null) continue;

            if (Physics.Raycast(
                    point.position,
                    Vector3.down,
                    checkDistance,
                    groundLayers,
                    QueryTriggerInteraction.Ignore))
            {
                return true;
            }
        }

        return false;
    }

    private void UpdateCoyoteTime()
    {
        if(IsGrounded) currentCoyoteTime = coyoteTime;
        else currentCoyoteTime = Mathf.Clamp(currentCoyoteTime -= Time.deltaTime, 0, coyoteTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoints == null) return;

        Gizmos.color = IsGrounded ? Color.green : Color.red;

        for (int i = 0; i < groundCheckPoints.Count; i++)
        {
            Transform point = groundCheckPoints[i];
            if (point == null) continue;

            Gizmos.DrawLine(point.position, point.position + Vector3.down * checkDistance);
            Gizmos.DrawWireSphere(point.position + Vector3.down * checkDistance, 0.025f);
        }
    }
}
