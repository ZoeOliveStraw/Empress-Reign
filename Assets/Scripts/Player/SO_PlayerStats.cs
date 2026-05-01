using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [CreateAssetMenu(fileName = "SO_PlayerStats", menuName = "Scriptable Objects/SO_PlayerStats")]
    public class SO_PlayerStats : ScriptableObject
    {
        [Header("BASE VALUES")]
        [SerializeField] private float baseMoveSpeed;
        [SerializeField] public float baseAccelleration;
        [SerializeField] public float baseLookSensitivity;
        [SerializeField] public float baseJumpForce;
        [SerializeField] private float baseAttackDamage;

        [Header("CORE STATS")] 
        [SerializeField] public int vitality = 0;
        [SerializeField] public int stamina = 0;
        [SerializeField] public int intelligence = 0;
        [SerializeField] public int strength = 0;
        [SerializeField] public int agility = 0;
        [SerializeField] public int willpower = 0;

        [Header("VALUE CONTRIBUTIONS FROM STATS")] 
        [SerializeField] private int hitPointsPerVitality = 10;
        [SerializeField] private int staminaPointsPerStamina = 10;
        [SerializeField] private int manaPointsPerIntelligence = 10;
        [SerializeField] private float plusAttackDamagePerStrength = 0.2f;
        [SerializeField] private float plusMoveSpeedPerAgility = 0.2f;
        [SerializeField] private float plusSpellDamagePerWillpower = 0.2f;

        public float GetAttackDamageModifier()
        {
            return baseAttackDamage + (strength * plusAttackDamagePerStrength);
        }

        public float GetMoveSpeed()
        {
            return baseMoveSpeed + (agility * plusMoveSpeedPerAgility);
        }
        
        
    }
}
