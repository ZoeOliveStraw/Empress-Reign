using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] public SO_PlayerStats stats;
        [SerializeField] private bool debugMode;

        public float MoveSpeed => GetMoveSpeed();
        public float Acceleration => GetAcceleration();
        public float JumpForce => GetJumpForce();
        public float LookSpeed => GetLookSpeed();
        
        private float GetMoveSpeed()
        {
            if(debugMode) return stats.GetMoveSpeed();
            //TODO PROPER STAT CALCULATION
            return 1;
        }
        
        private float GetAcceleration()
        {
            if(debugMode) return stats.baseAccelleration;
            //TODO PROPER STAT CALCULATION
            return 1;
        }

        private float GetJumpForce()
        {
            if (debugMode) return stats.baseJumpForce;
            //TODO PROPER STAT CALCULATION
            return 1;
        }

        private float GetLookSpeed()
        {
            if (debugMode) return stats.baseLookSensitivity;
            //TODO PROPER STAT CALCULATION
            return 1;
        }
    }
}
