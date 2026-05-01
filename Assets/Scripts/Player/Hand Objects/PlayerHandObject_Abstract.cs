using UnityEngine;

public abstract class PlayerHandObject_Abstract : MonoBehaviour
{
    [SerializeField] private Transform rightHandTransform;
    [SerializeField] private Transform leftHandTransform;
    
    [SerializeField] protected Animator animator;
    [SerializeField] protected string playAnimationName;
    
    public abstract void PlayUseAnimation();
}
