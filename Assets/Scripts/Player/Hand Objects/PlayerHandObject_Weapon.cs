using System.Collections.Generic;
using UnityEngine;

public class PlayerHandObject_Weapon : PlayerHandObject_Abstract
{
    [SerializeField] private List<Transform> checkPoints;
    [SerializeField] private float checkPointRadius = 0.1f;
    [SerializeField] private LayerMask layerMask;
    
    public override void PlayUseAnimation()
    {
        animator.StopPlayback();
        animator.Play(playAnimationName, -1, 0f);
    }

    public List<Hurtbox> CheckPointsForDamangeable()
    {
        Collider[] results = new Collider[8];
        List<Hurtbox> hitObjects = new List<Hurtbox>();
        foreach (Transform checkPoint in checkPoints)
        {
            int count = Physics.OverlapSphereNonAlloc(
                checkPoint.position,
                checkPointRadius,
                results,
                layerMask,
                QueryTriggerInteraction.Ignore
            );
            for (int i = 0; i < count; i++)
            {
                Hurtbox hurtbox = results[i].GetComponent<Hurtbox>();
                if (hurtbox != null && !hitObjects.Contains(hurtbox))
                {
                    hitObjects.Add(hurtbox);
                }
            }
        }
        return hitObjects;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (checkPoints == null) return;

        Gizmos.color = Color.red;

        for (int i = 0; i < checkPoints.Count; i++)
        {
            if (checkPoints[i] != null)
            {
                Gizmos.DrawWireSphere(checkPoints[i].position, checkPointRadius);
            }
        }
    }

}
