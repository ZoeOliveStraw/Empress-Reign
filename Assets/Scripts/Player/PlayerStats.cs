using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private SO_PlayerStats debugPlayerStats;
        [SerializeField] private bool debugMode;

        public float MoveSpeed => GetMoveSpeed();
        public float Acceleration => GetAcceleration();
        public float JumpForce => GetJumpForce();
        public float LookSpeed => GetLookSpeed();
        
        private float GetMoveSpeed()
        {
            if(debugMode) return debugPlayerStats.GetMoveSpeed();
            //TODO PROPER STAT CALCULATION
            return 1;
        }
        
        private float GetAcceleration()
        {
            if(debugMode) return debugPlayerStats.baseAccelleration;
            //TODO PROPER STAT CALCULATION
            return 1;
        }

        private float GetJumpForce()
        {
            if (debugMode) return debugPlayerStats.baseJumpForce;
            //TODO PROPER STAT CALCULATION
            return 1;
        }

        private float GetLookSpeed()
        {
            if (debugMode) return debugPlayerStats.baseLookSensitivity;
            //TODO PROPER STAT CALCULATION
            return 1;
        }
    }
}
